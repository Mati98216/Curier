using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurierProject.Domain;
using CurierProject.Domain.Contracts;
using CurierProject.Domain.Models;
using CurierProject.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CurierProject.Controllers
{
    public class BaseController : Controller
    {
        protected DomainContext Context { get; set; }
        protected ICurrentUser CurrentUser { get; set; }
        protected UserManager<ApplicationUser> UserManager { get; set; }
        protected HttpContextBase ContextBase { get; set; }
        public BaseController(DomainContext context,
            UserManager<ApplicationUser> userManager,
            ICurrentUser currentUser,
            HttpContextBase contextBase)
        {
            Context = context;
            UserManager = userManager;
            CurrentUser = currentUser;
            ContextBase = contextBase;
        }

        protected int GetLoggedInUserID()
        {
            return CurrentUser.User.PersonID;
        }
    }
}