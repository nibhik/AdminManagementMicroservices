using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;
using AdminManagement.Domain.Aggregates.AdminAggregate;

namespace AdminManagement.Infrastructure.Data.Config
{
     public class DoctorEntityTypeConfiguration :IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(m => m.FullName).HasMaxLength(30).IsRequired(true);
            builder.Property(m => m.Specialization).HasMaxLength(100).IsRequired(true);
            builder.Property(m => m.Education).HasMaxLength(50).IsRequired(true);
        }
    }
}
