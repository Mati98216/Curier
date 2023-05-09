using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurierProject.Domain
{
    public class ApplicationRoles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Courier = "Courier";
    }

    public enum AppRoles
    {
        Admin, User, Courier
    }
}
