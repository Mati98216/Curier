using CurierProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurierProject.Domain.Handlers.Queries
{
    public class GetRolesQuery
    {
        protected DomainContext _context;
        public GetRolesQuery(DomainContext context)
        {
            _context = context;
        }

        public IQueryable<Roles> Execute()
        {
            return _context.Roles;
        }
    }
}
