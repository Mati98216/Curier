using CurierProject.Domain.Contracts;
using CurierProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CurierProject.Domain;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CurierProject.Models
{
    public class AdministrationsDeleteViewModel : IDeletePerson
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}