using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurierProject.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CurierProject.Domain
{
    public class DomainContext : IdentityDbContext<ApplicationUser>
    {
        public DomainContext() : this("DomainContext")
        {
        }
        public DomainContext(string connectionString) : base("DomainContext")
        {
            
        }
        
        public DbSet<Packages> Packages { get; set; }
        public DbSet<PackageStatus> PackageStatus { get; set; }
        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<Shipments> Shipments { get; set; }
        public DbSet<Person> Persons { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static DomainContext Create()
        {
            return new DomainContext();
        }
    }
}
