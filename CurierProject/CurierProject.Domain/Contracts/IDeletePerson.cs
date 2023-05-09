using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurierProject.Domain.Contracts
{
   public interface IDeletePerson
    {
        int ID { get; set; }
        bool IsActive { get; set; }
    }
}
