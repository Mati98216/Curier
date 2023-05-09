using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurierProject.Domain.Models;

namespace CurierProject.Domain.Handlers.Queries
{
    public class GetAssignmentsQuery
    {
        protected DomainContext _context;
        public GetAssignmentsQuery(DomainContext context)
        {
            _context = context;
        }

        public IQueryable<Assignments> Execute()
        {
            return _context.Assignments;
        }
    }
}
