using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;
using AdminManagement.Domain.Aggregates.AdminAggregate;

namespace AdminManagement.Infrastructure.Data.Config
{
    public class PatientEntityTypeConfiguration :IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(m => m.Diagnosis).HasMaxLength(30).IsRequired(true);
            builder.Property(m => m.Treatment).HasMaxLength(100).IsRequired(true);
            builder.Property(m => m.Prescription).HasMaxLength(100).IsRequired(true);
            builder.Property(m => m.Problem).HasMaxLength(100).IsRequired(true);
        }
    }
}
