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
    public class InsertOrUpdatePersonCommand
    {
        private readonly DomainContext _context;
        private readonly InsertOrUpdateUserCommand _insertOrUpdateUserCommand;
        public InsertOrUpdatePersonCommand(DomainContext context, InsertOrUpdateUserCommand insertOrUpdateUserCommand)
        {
            _context = context;
            _insertOrUpdateUserCommand = insertOrUpdateUserCommand;
        }

        public int? Execute(IInsertOrUpdatePerson command)
        {
            var person = _context.Persons.FirstOrDefault(x => x.ID == command.ID);
            
            if (person == null)
            {
                var userList = _context.Users.Where(x => x.Email == command.Email);
                if (userList.Any())
                    return 0;

                person = new Person();
                person.FirstName = command.FirstName;
                person.LastName = command.LastName;
                person.Email = command.Email;
                person.Phone = command.Phone;
                person.Address = command.Address;
                person.IsActive = command.IsActive;
                _context.Persons.Add(person);
                _context.SaveChanges();
                var result = _insertOrUpdateUserCommand.Execute(person, command.Email, command.Password, command.Role);
            }
            else
            {
                person.FirstName = command.FirstName;
                person.LastName = command.LastName;
                person.Email = command.Email;
                person.Phone = command.Phone;
                person.Address = command.Address;
                person.IsActive = command.IsActive;
                var result = _insertOrUpdateUserCommand.Execute(person, command.Email, command.Password, command.Role);
            }
            _context.SaveChanges();
            return person.ID;
        }
    }
}
