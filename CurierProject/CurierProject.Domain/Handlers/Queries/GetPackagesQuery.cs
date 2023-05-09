using System.Data.Entity;
using System.Linq;
using CurierProject.Domain.Models;

namespace CurierProject.Domain.Handlers.Queries
{
    public class GetPackagesQuery
    {
        protected DomainContext _context;
        public GetPackagesQuery(DomainContext context)
        {
            _context = context;
        }

        public IQueryable<Packages> Execute()
        {
            return _context.Packages
                .Include(e => e.Sender)
                .Include(e => e.Recipient)
                .Include(e => e.Status);
        }

        public Packages Execute(int id)
        {
            return _context.Packages
                .Include(e => e.Recipient)
                .Include(e => e.Status)
                .Include(e => e.Sender)
                .FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Assignments> ExecuteGetAssignments()
        {
            return _context.Assignments
                .Include(e => e.Courier)
                .Include(e => e.Package)
                .Include(e => e.Package.Status)
                .Include(e => e.Shipment);
        }

        public IQueryable<Assignments> ExecuteGetAssignmentsForCourier(int courierID)
        {
            return _context.Assignments.Where(e => e.CourierID == courierID && e.Package.Status.All(_ => _.Status != PackageStatusEnum.Delivered))
                .Include(e => e.Package)
                .Include(e => e.Package.Status)
                .Include(e => e.Courier)
                .Include(e => e.Shipment);
        }


        public IQueryable<Shipments> ExecuteGetShipments()
        {
            return _context.Shipments
                .Include(e => e.Package)
                .Include(e => e.Package.Sender)
                .Include(e => e.Package.Recipient)
                .Include(e => e.Package.Status);
        }

        public Shipments ExecuteGetShipments(int id)
        {
            return _context.Shipments.FirstOrDefault(e => e.Package.ID == id);
        }
    }
}
