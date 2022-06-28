using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AdminManagement.Domain.Aggregates.AdminAggregate;

namespace AdminManagement.Infrastructure.Data.Contexts
{
    public class AdminMAnagementContext: DbContext
    {
        public AdminMAnagementContext( DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdminMAnagementContext).Assembly);
        }
    }
}
