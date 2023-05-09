using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurierProject.Domain.Contracts;
using CurierProject.Domain.Models;

namespace CurierProject.Domain.Handlers.Commands
{
    public class InsertOrUpdatePackageCommand
    {
        private readonly DomainContext _context;
        private readonly InsertOrUpdateUserCommand _insertOrUpdateUserCommand;
        public InsertOrUpdatePackageCommand(DomainContext context, InsertOrUpdateUserCommand insertOrUpdateUserCommand)
        {
            _context = context;
            _insertOrUpdateUserCommand = insertOrUpdateUserCommand;
        }

        public int? Execute(IInsertOrUpdatePackage command)
        {
            var package = _context.Packages.FirstOrDefault(x => x.ID == command.ID);
            if (package == null)
            {
                package = new Packages();
                package.PackageWeight = command.Weight;
                package.PackageSize = command.Size;
                package.PackageDescription = command.Description;
                package.SenderID = command.SenderID;
                package.RecipientID = command.RecipientID;
                _context.Packages.Add(package);
                _context.SaveChanges();

                if (package.ID != 0)
                {
                    var packageStatus = new PackageStatus
                    {
                        PackageID = package.ID,
                        Status = PackageStatusEnum.Created,
                        UpdatedOn = DateTime.Now
                    };
                    _context.PackageStatus.Add(packageStatus);
                }

                if (package.ID != 0)
                {
                    var shipment = new Shipments
                    {
                        PackageID = package.ID,
                        ShipmentDate = null,
                        EstimatedDeliveryDate = DateTime.Now.AddDays(7),
                        ActualDeliveryDate = null
                    };
                    _context.Shipments.Add(shipment);
                }
            }
            else
            {
                package.PackageWeight = command.Weight;
                package.PackageSize = command.Size;
                package.PackageDescription = command.Description;
                package.SenderID = command.SenderID;
                package.RecipientID = command.RecipientID;
            }
            _context.SaveChanges();
            return package.ID;
        }

        public int? AssignNewCourierToPackage(IInsertOrUpdateAssignedPackage command)
        {
            var assignment = new Assignments
            {
                ShipmentID = command.ShipmentID,
                CourierID = command.CourierID,
                PackageID = command.PackageID,
            };
            _context.Assignments.Add(assignment);
            
            var packageStatus = new PackageStatus
            {
                PackageID = command.PackageID,
                Status = PackageStatusEnum.InProgress,
                UpdatedOn = DateTime.Now
            };
            _context.PackageStatus.Add(packageStatus);

            var shipments = _context.Shipments.Find(command.ShipmentID);
            if (shipments != null)
            {
                shipments.EstimatedDeliveryDate = DateTime.Now;
            }
            else
            {
                var shipment = new Shipments
                {
                    PackageID = command.PackageID,
                    ShipmentDate = null,
                    EstimatedDeliveryDate = DateTime.Now,
                    ActualDeliveryDate = null
                };
                _context.Shipments.Add(shipment);
            }
            _context.SaveChanges();

            if (assignment.ID > 0)
            {
                return assignment.ID;
            }

            return 0;
        }

        public int? DeliverPackage(IDeliveryPackage command)
        {
            var packageStatus = new PackageStatus
            {
                PackageID = command.PackageID,
                Status = PackageStatusEnum.Delivered,
                UpdatedOn = DateTime.Now
            };
            _context.PackageStatus.Add(packageStatus);
            _context.SaveChanges();
            return 0;
        }
    }
}
