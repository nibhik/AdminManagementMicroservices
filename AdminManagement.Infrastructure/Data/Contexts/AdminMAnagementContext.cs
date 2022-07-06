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
        public DbSet<Department> Department { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AdminMAnagementContext).Assembly);
        }
    }
}
