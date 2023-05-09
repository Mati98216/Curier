using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CurierProject.Domain.Contracts;
using CurierProject.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CurierProject.Domain.Handlers.Commands
{
    public class InsertOrUpdateUserCommand
    {
        private readonly DomainContext _context;
        private readonly UserManager<ApplicationUser> userManager;

        public InsertOrUpdateUserCommand(DomainContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public string Execute(Person person, string email, string password, string role)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email);

            if (user == null)
            {
                user = new ApplicationUser();
                user.PersonID = person.ID;
                user.Email = email;
                user.PasswordHash = password;
                user.UserName = email;
                user.EmailConfirmed = true;
                user.PhoneNumberConfirmed = true;
                user.TwoFactorEnabled = false;
                user.LockoutEnabled = false;
                user.AccessFailedCount = 0;
                var result = userManager.Create(user, user.PasswordHash);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, role);
                }
            }
            else
            {
                userManager.RemoveFromRole(user.Id, userManager.GetRoles(user.Id).FirstOrDefault());
                userManager.AddToRole(user.Id, role);
                user.Email = email;
                user.PasswordHash = password;
            }
            _context.SaveChanges();
            return user.Id.ToString();
        }
    }
}
