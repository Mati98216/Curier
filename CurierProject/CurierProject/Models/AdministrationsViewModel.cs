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
    public class AdministrationsViewModel : IInsertOrUpdatePerson
    {

        public int ID { get; set; }
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public int Phone { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

       
        public List<SelectListItem> Roles { get; set; }
       
        }
    }
