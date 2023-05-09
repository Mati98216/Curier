using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurierProject.Domain.Models;

namespace CurierProject.Domain.Contracts
{
    public interface IInsertOrUpdatePackage
    {
        int ID { get; set; }
        decimal Weight { get; set; }
        PackageSize Size { get; set; }
        string Description { get; set; }
        int SenderID { get; set; }
        int RecipientID { get; set; }
    }

    public interface IInsertOrUpdateAssignment
    {
        int PackageID { get; set; }
        int CourierID { get; set; }
        int StatusID { get; set; }
        DateTime UpdatedOn { get; set; }
        DateTime CreatedOn { get; set; }
    }

    public interface IDeliveryPackage
    {
        int PackageID { get; set; }
    }
}
