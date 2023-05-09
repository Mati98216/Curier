using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CurierProject.Domain.Contracts
{
    public interface IRegisterUser
    {
        int ID { get; set; }  
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
        int Phone { get; set; }
        string Address { get; set; }
        bool IsActive { get; set; }
        string Role { get; set; }
    }
}
