using Autofac;
using CurierProject.Domain.Contracts;
using CurierProject.Domain.Handlers.Queries;
using CurierProject.Domain;
using CurierProject.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using CurierProject.Domain.Models;
using System.Data.Entity;
using CurierProject.Domain.Handlers.Commands;

namespace CurierProject
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            var builder = new ContainerBuilder();

            // Register your controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.Register(c => new HttpContextWrapper(HttpContext.Current) as HttpContextBase).As<HttpContextBase>().InstancePerRequest();
            // Register your other dependencies
            builder.RegisterType<DomainContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<DomainContext>().As<DomainContext>();
            builder.RegisterType<ApplicationUser>().As<ApplicationUser>();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>();
            builder.RegisterType<CurrentUser>().As<ICurrentUser>();
            builder.RegisterType<UserManager<ApplicationUser>>().As<UserManager<ApplicationUser>>();
            builder.RegisterType<GetPackagesQuery>().As<GetPackagesQuery>(); 
            builder.RegisterType<GetAssignmentsQuery>().As<GetAssignmentsQuery>();
            builder.RegisterType<GetPersonsQuery>().As<GetPersonsQuery>();
            builder.RegisterType<InsertOrUpdatePersonCommand>().As<InsertOrUpdatePersonCommand>();
            builder.RegisterType<InsertOrUpdateUserCommand>().As<InsertOrUpdateUserCommand>();
            builder.RegisterType<InsertOrUpdatePackageCommand>().As<InsertOrUpdatePackageCommand>();
            builder.RegisterType<DeletePersonCommand>().As<DeletePersonCommand>();

            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DomainContext()));

            var container = builder.Build();

            // Set the dependency resolver for MVC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
