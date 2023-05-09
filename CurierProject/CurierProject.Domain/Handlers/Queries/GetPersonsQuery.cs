using CurierProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurierProject.Domain.Handlers.Queries
{
    public class GetPersonsQuery
    {
        protected DomainContext _context;
        public GetPersonsQuery(DomainContext context)
        {
            _context = context;
        }

        public IQueryable<Person> Execute()
        {
            return _context.Persons;
        }

        public Person Execute(int ID)
        {
            return _context.Persons.FirstOrDefault(a => a.ID == ID);
        }

        public IQueryable<ApplicationUser> ApplicationUsersWithGivenRole(string roleName)
        {
            return _context.Users.Where(x =>
                x.Roles.Any(y => y.RoleId==  _context.Roles.FirstOrDefault(z => z.Name==  roleName).Id));
        }
    }
}
