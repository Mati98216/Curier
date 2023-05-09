using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurierProject.Domain.Models
{
    public class PackageStatus
    {
        public int ID { get; set; }
        public int PackageID { get; set; }
        public PackageStatusEnum Status { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Packages Package { get; set; }
    }

    public enum PackageStatusEnum
    {
        Created = 0,
        InProgress = 1,
        Delivered = 2,
        Canceled = 3,
    }
}