using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurierProject.Domain.Models
{
    public class Assignments
    {
        public int ID { get; set; }
        public int ShipmentID { get; set; }
        public int CourierID { get; set; }
        public int PackageID { get; set; }

        public Shipments Shipment { get; set; }
        public Person Courier { get; set; }
        public Packages Package { get; set; }
    }
}
