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
    [Authorize(Roles = ApplicationRoles.Courier)]
    public class CourierController : BaseController
    {
        private readonly GetPackagesQuery _getPackagesQuery;
        private readonly InsertOrUpdatePackageCommand _insertOrUpdatePackageCommand;

        public CourierController(DomainContext context,
            UserManager<ApplicationUser> userManager,
            ICurrentUser currentUser,
            HttpContextBase contextBase, GetPackagesQuery getPackagesQuery, InsertOrUpdatePackageCommand insertOrUpdatePackageCommand) : base(context,
            userManager,
            currentUser,
            contextBase)
        {
            _getPackagesQuery = getPackagesQuery;
            _insertOrUpdatePackageCommand = insertOrUpdatePackageCommand;
        }
        
        public ActionResult Index()
        {
            var assignments = _getPackagesQuery.ExecuteGetAssignmentsForCourier(CurrentUser.ID).ToList();
            var model = new List<PackageInformationViewModel>();

            foreach (var data in assignments)
            {
                model.Add(new PackageInformationViewModel
                {
                    ID = data.Package.ID,
                    Recipient = data.Package.Recipient,
                    PackageDescription = data.Package.PackageDescription,
                    PackageSize = data.Package.PackageSize,
                    PackageWeight = data.Package.PackageWeight,
                    Status = data.Package.GetLatesStatus().Status,
                });
            }
            return View("Index", model);
        }

        public ActionResult PackageDetails(int id)
        {
            var data = _getPackagesQuery.ExecuteGetAssignments().FirstOrDefault(e => e.PackageID == id);

            var model = new PackageInformationViewModel();
            if (data != null)
            {
                model = new PackageInformationViewModel()
                {
                    ID = id,
                    Sender = data.Package.Sender,
                    Recipient = data.Package.Recipient,
                    PackageWeight = data.Package.PackageWeight,
                    PackageSize = data.Package.PackageSize,
                    PackageDescription = data.Package.PackageDescription,
                    Status = data.Package.GetLatesStatus().Status,
                };
            }

            return View("PackageDetails", model);
        }

        public ActionResult PackageManagement()
        {
            var assignments = _getPackagesQuery.ExecuteGetAssignments().ToList();
            var packageData = _getPackagesQuery.Execute().ToList();
            var model = new List<PackageManagementViewModel>();

            foreach (var package in packageData)
            {
                if (assignments.Any(e => e.Package.ID == package.ID))
                    continue;

                var shipmentID = _getPackagesQuery.ExecuteGetShipments(package.ID).ID;

                model.Add(new PackageManagementViewModel
                {
                    ID = package.ID,
                    Sender = package.Sender,
                    Recipient = package.Recipient,
                    PackageSize = package.PackageSize,
                    PackageWeight = package.PackageWeight,
                    PackageDescription = package.PackageDescription,
                    ShipmentID = shipmentID
                });
            }
            return View("PackageManagement", model);
        }

        public ActionResult EditPackageStatus(int id)
        {
            var data = _getPackagesQuery.Execute(id);
            var model = new EditPackageDetailsViewModel();

            model.Recipient = data.Recipient;
            model.PackageID = data.ID;

            return PartialView("_EditPackageStatus", model);
        }

        [HttpPost]
        public ActionResult GetThisPackage(int id, int shipmentID)
        {
            var model = new AssignPackageViewModel
            {
                PackageID = id,
                CourierID = CurrentUser.ID,
                ShipmentID = shipmentID,
            };

            var result = _insertOrUpdatePackageCommand.AssignNewCourierToPackage(model);

            return RedirectToAction("PackageManagement");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeliveryPackage(EditPackageDetailsViewModel model)
        {
            var result = _insertOrUpdatePackageCommand.DeliverPackage(model);

            return RedirectToAction("Index");
        }
    }

    
}