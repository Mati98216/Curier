using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurierProject.Domain;
using CurierProject.Domain.Contracts;
using CurierProject.Domain.Handlers.Commands;
using CurierProject.Domain.Handlers.Queries;
using CurierProject.Domain.Models;
using CurierProject.Models;
using Microsoft.AspNet.Identity;

namespace CurierProject.Controllers
{
    [Authorize(Roles = ApplicationRoles.User)]
    public class HomeController : BaseController
    {
        private readonly GetPackagesQuery _getPackagesQuery;
        private readonly GetPersonsQuery _getPersonsQuery;
        private readonly InsertOrUpdatePackageCommand _insertOrUpdatePackageCommand;

        public HomeController(DomainContext context, UserManager<ApplicationUser> userManager, ICurrentUser currentUser, HttpContextBase contextBase, GetPackagesQuery getPackagesQuery, GetPersonsQuery getPersonsQuery, InsertOrUpdatePackageCommand insertOrUpdatePackageCommand) : base(context, userManager, currentUser, contextBase)
        {
            _getPackagesQuery = getPackagesQuery;
            _getPersonsQuery = getPersonsQuery;
            _insertOrUpdatePackageCommand = insertOrUpdatePackageCommand;
        }

        // GET: Home
        public ActionResult Index()
        {
            var data = _getPackagesQuery.ExecuteGetShipments().Where(e=>e.Package.RecipientID==CurrentUser.ID||e.Package.SenderID==CurrentUser.ID);
            var modal = new List<UsersPackegesViewModel>();
            foreach (var package in data)
            {
                modal.Add(new UsersPackegesViewModel()
                {
                    Id = package.ID,
                    Recipient = package.Package.Recipient.GetFullName(),
                    Status = package.Package.GetLatesStatus().Status,
                    ShipmentDate = package.ShipmentDate ?? DateTime.Now,
                    IsCourierAssigment = _getPackagesQuery.ExecuteGetAssignments().Any(e=>e.PackageID==package.ID),
                });
            }
            return View(modal);
        }

        public ActionResult PackageDetails(int Id)
        {
            var data = _getPackagesQuery.ExecuteGetAssignments().FirstOrDefault(e => e.PackageID == Id);
            var modal = new PackegeDetailViewModel();
            modal.Id = Id;
            modal.ShipmentDate = data.Shipment.ShipmentDate ?? DateTime.Now;
            modal.Status = data.Package.GetLatesStatus().Status;
            modal.Recipient = data.Package.Recipient.GetFullName();
            modal.CFirstName = data.Courier.FirstName.ToString();
            modal.CPhone = data.Courier.Phone.ToString();

            return View(modal);
        }

        [HttpGet]
        public ActionResult CreateNewPackage()
        {
            var model = new CreateNewPackageViewModel();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateNewPackageViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.SenderID = CurrentUser.ID;
                var recipient = _getPersonsQuery.Execute().FirstOrDefault(e => e.Email == model.RecipientEmail);

                if (recipient == null)
                {
                    return RedirectToAction("CreateNewPackage");
                }

                model.RecipientID = recipient.ID;

                var result = _insertOrUpdatePackageCommand.Execute(model);
                if (result > 0)
                {
                    return RedirectToAction("index");
                }
            }

            return RedirectToAction("CreateNewPackage");

        }
    }
}