using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurierProject.Domain.Models;
using Microsoft.AspNet.Identity;

namespace CurierProject.Domain.Contracts
{
    public interface ICurrentUser
    {
        ApplicationUser User { get; }
        string FullName { get; }
        int ID { get; }
    }
}
