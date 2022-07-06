using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;
using AdminManagement.Domain.Aggregates.AdminAggregate;


namespace AdminManagement.Infrastructure.Data.Config
{
    public class DeaprtmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Consultant).HasMaxLength(30).IsRequired(true);
            builder.Property(m => m.DepartmentName).HasMaxLength(50).IsRequired(true);
            builder.Property(m => m.Category).HasMaxLength(30).IsRequired(true);
        }

    }
}
