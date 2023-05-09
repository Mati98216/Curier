using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using CurierProject.Domain;
using CurierProject.Domain.Contracts;
using CurierProject.Domain.Models;
using Microsoft.AspNet.Identity;

namespace CurierProject.Infrastructure
{
    public class CurrentUser : ICurrentUser
    {
        private readonly HttpContextBase _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DomainContext _domainContext;

        public CurrentUser(UserManager<ApplicationUser> userManager, HttpContextBase context, DomainContext domainContext)
        {
            _userManager = userManager;
            _context = context;
            _domainContext = domainContext;
        }

        public ApplicationUser User
        {
            get
            {
                var userId = _context.User.Identity.GetUserId();
                return _userManager.FindById(userId);
            }
        }

        public string FullName
        {
            get
            {
                var person = _domainContext.Persons.FirstOrDefault(e => e.ID == ID);
                return person.FirstName + " " + person.LastName;
            }
        }

        public int ID
        {
            get
            {
                return User.PersonID;
            }
        }
    }
}