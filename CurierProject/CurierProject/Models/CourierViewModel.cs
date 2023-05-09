using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurierProject.Domain.Contracts;
using CurierProject.Domain.Models;

namespace CurierProject.Models
{
    public class CourierViewModel
    {
        
    }

    public class PackageInformationViewModel
    {
        public int ID { get; set; }
        public Person Sender { get; set; }
        public Person Recipient { get; set; }
        public decimal PackageWeight { get; set; }
        public PackageSize PackageSize { get; set; }
        public string PackageDescription { get; set; }
        public PackageStatusEnum Status { get; set; }
    }

    public class EditPackageDetailsViewModel : IDeliveryPackage
    {
        public Person Recipient { get; set; }
        public int PackageID { get; set; }
    }

    public class PackageManagementViewModel : PackageInformationViewModel
    {
        public DateTime? EstimatedDeliveryDate { get; set; }
        public int ShipmentID { get; set; }
    }

    public class AssignPackageViewModel : IInsertOrUpdateAssignedPackage
    {
        public int PackageID { get; set; }
        public int CourierID { get; set; }
        public int ShipmentID { get; set; }
    }
}