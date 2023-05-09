using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurierProject.Domain.Models
{
    public class Shipments
    {
        public int ID { get; set; }
        public int PackageID { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }

        public Packages Package { get; set; }
    }
}
