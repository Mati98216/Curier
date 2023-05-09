using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurierProject.Domain.Models
{
    public class Packages
    {
        public int ID { get; set; }
        public int SenderID { get; set; }
        public int RecipientID { get; set; }
        public decimal PackageWeight { get; set; }
        public PackageSize PackageSize { get; set; }
        public string PackageDescription { get; set; }

        public Person Sender { get; set; }
        public Person Recipient { get; set; }
        public ICollection<PackageStatus> Status { get; set; }

        public PackageStatus GetLatesStatus()
        {
            return Status.OrderByDescending(e => e.UpdatedOn).FirstOrDefault();
        }
    }

    public enum PackageSize
    {
        Small,
        Medium,
        Large
    }
}
