using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurierProject.Domain.Contracts;
using CurierProject.Domain.Models;

namespace CurierProject.Models
{
    public class HomeViewModel
    {
    }

    public class PackegeDetailViewModel
    {
        public int Id { get; set; }
        public DateTime ShipmentDate { get; set; }
        public PackageStatusEnum Status { get; set; }
        public string Recipient { get; set; }
        public string CFirstName { get; set; }
        public string CPhone { get; set; }
    }

    public class UsersPackegesViewModel
    {
        public int Id { get; set; }
        public DateTime ShipmentDate { get; set; }
        public PackageStatusEnum Status { get; set; }
        public string Recipient { get; set; }
        public bool IsCourierAssigment { get; set; }
    }

    public class CreateNewPackageViewModel : IInsertOrUpdatePackage
    {
        public int ID { get; set; }

        [Required]
        public decimal Weight { get; set; }
        public PackageSize Size { get; set; }
        public string Description { get; set; }
        public int SenderID { get; set; }
        public int RecipientID { get; set; }

        [EmailAddress]
        [Required]
        public string RecipientEmail { get; set; }
    }
}