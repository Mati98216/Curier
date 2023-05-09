using CurierProject.Domain.Contracts;
using CurierProject.Domain.Handlers.Queries;
using CurierProject.Domain.Models;
using CurierProject.Domain;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurierProject.Models;
using System.Web.Mvc.Html;
using CurierProject.Domain.Extensions;
using CurierProject.Domain.Handlers.Commands;
using Microsoft.Ajax.Utilities;
using System.Net;
using System.Web.Security;
using System.Data;

namespace CurierProject.Controllers
{
    [Authorize(Roles = ApplicationRoles.Admin)]
    public class AdministrationsController : BaseController
    {
        private readonly GetPersonsQuery _getPersonsQuery;
        private readonly InsertOrUpdatePersonCommand _inserOrUpdatePersonCommand;
        private readonly DeletePersonCommand _deletePersonCommand;
        // GET: Administrations
        public AdministrationsController(DomainContext context, UserManager<ApplicationUser> userManager, ICurrentUser currentUser, HttpContextBase contextBase, GetPersonsQuery getPersonsQuery, InsertOrUpdatePersonCommand insertOrUpdatePersonCommand, DeletePersonCommand deletePersonCommand) : base(context, userManager, currentUser, contextBase)
        {
            _getPersonsQuery = getPersonsQuery;
            _inserOrUpdatePersonCommand = insertOrUpdatePersonCommand;
            _deletePersonCommand = deletePersonCommand;
        }
        public ActionResult Index()
        {
       
           var list = _getPersonsQuery.Execute().ToList();
            var a= new List<AdministrationsViewModel>();
            var roles = Context.Roles.ToList();
            foreach (var person in list)
            {
                var userID = UserManager.Users.FirstOrDefault(e => e.PersonID == person.ID)?.Id;

                a.Add(new AdministrationsViewModel {
                    ID =person.ID,
                    FirstName=person.FirstName,
                    LastName=person.LastName,
                    Email=person.Email,
                    Phone=person.Phone,
                    Address=person.Address,
                    IsActive=person.IsActive,
                    Role = UserManager.GetRoles(userID).FirstOrDefault()?.ToString(),
                });
            }
            return View(a);
       
        }
        public ActionResult Edit(int ID)
        {   
            var person = _getPersonsQuery.Execute(ID);
            var userID = UserManager.Users.FirstOrDefault(e => e.PersonID == person.ID)?.Id;
            var view = new AdministrationsViewModel { 
                ID=ID,
                FirstName=person.FirstName,
                LastName=person.LastName,
                Email=person.Email,
                Phone=person.Phone,
                Address=person.Address,
                IsActive=person.IsActive,
                Password=person.Password,
                Role= UserManager.GetRoles(userID).FirstOrDefault()?.ToString(),
                Roles = new List<SelectListItem>()
            };

            var roles = Context.Roles.ToList();

            foreach (var item in roles)
            {
                view.Roles.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Name
                });
            }

            return View("EditView", view);
        }

        public ActionResult AddUser(int ID)
        {   
            var roles=Context.Roles.ToList();

            var model = new AdministrationsViewModel
            {
                ID = ID,
                Roles = new List<SelectListItem>()

            };
            foreach(var item in roles)
            {
                model.Roles.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Name
                });
            }

            return PartialView("_AddView", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdministrationsViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var result = _inserOrUpdatePersonCommand.Execute(model);
                if (result > 0)
                {
                    ModelState.AddModelError("", "Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            
            return RedirectToAction("Index");
        }
       public ActionResult Delete(int ID)
        {
            var model = new AdministrationsDeleteViewModel
            {
                ID = ID

            };


            return View("DeleteView",model);
        }

        public ActionResult DeleteAccount(AdministrationsDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {

                var result = _deletePersonCommand.Execute(model);
                if (result > 0)
                {
                    ModelState.AddModelError("", "Error");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

    }
}