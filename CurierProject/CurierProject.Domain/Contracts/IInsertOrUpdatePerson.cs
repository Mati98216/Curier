using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurierProject.Domain.Contracts
{
    public interface IInsertOrUpdatePerson
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        int Phone { get; set; }
        string Address { get; set; }
        string Role { get; set; }
        bool IsActive { get; set; }
        
    }
}
