using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurierProject.Domain.Contracts
{
    public interface IInsertOrUpdateAssignedPackage
    {
        int PackageID { get; set; }
        int CourierID { get; set; }
        int ShipmentID { get; set; }
    }
}
