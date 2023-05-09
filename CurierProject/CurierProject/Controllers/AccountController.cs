using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CurierProject.Domain;
using CurierProject.Domain.Contracts;
using CurierProject.Domain.Handlers.Commands;
using CurierProject.Domain.Models;
using CurierProject.Infrastructure;
using CurierProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace CurierProject.Controllers
{
    public class AccountController : BaseController
    {
        private readonly InsertOrUpdatePersonCommand _insertOrUpdatePersonCommand;
        
        public AccountController(DomainContext context, UserManager<ApplicationUser> userManager, ICurrentUser currentUser, HttpContextBase contextBase, InsertOrUpdatePersonCommand insertOrUpdatePersonCommand) : base(context, userManager, currentUser, contextBase)
        {

            _insertOrUpdatePersonCommand = insertOrUpdatePersonCommand;
            
        }
        // GET: Account
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid Email or password.");
                    return View(model);
                }
                await SignInAsync(user, model.RememberMe);
                CurrentUser = new CurrentUser(UserManager, HttpContext, Context);

                var roles = UserManager.GetRoles(user.Id).FirstOrDefault();

                if (roles != null)
                {
                    switch (roles)
                    {
                        case ApplicationRoles.Admin:
                            return RedirectToAction("Index", "Administrations");

                        case ApplicationRoles.Courier:
                            return RedirectToAction("Index", "Courier");

                        case ApplicationRoles.User:
                            return RedirectToAction("Index", "Home");
                    }
                }
                return RedirectToLocal(returnUrl);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            
        }
        public ActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterNewUser(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }

            model.IsActive = true;
            model.Role = ApplicationRoles.User;

            var resoult = _insertOrUpdatePersonCommand.Execute(model);

            if(resoult.HasValue)
            {
                return RedirectToAction("Login");
            }

            else
            {
                return View("Register", model);
            }
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager authenticationManager => HttpContext.GetOwinContext().Authentication;

        private async Task SignInAsync(ApplicationUser user, bool modelRememberMe)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = modelRememberMe }, await user.GenerateUserIdentityAsync(UserManager));
        }


        public ActionResult Logout()
        {
            var Authenticationmanager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();

            return RedirectToAction("Login");
        }
    }
}