using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using CurierProject.Domain.Contracts;
using CurierProject.Domain.Models;

namespace CurierProject.Domain.Handlers.Commands
{
    public class DeletePersonCommand
    {
        private readonly DomainContext _context;

        public DeletePersonCommand(DomainContext context)
        {
            _context = context;

        }
        public int? Execute(IDeletePerson command)
        {
            var person = _context.Persons.FirstOrDefault(x => x.ID == command.ID);
            if (person != null)
            {
                person.IsActive = false;

            }
            _context.SaveChanges();
            return person.ID;
        }
    }
}
