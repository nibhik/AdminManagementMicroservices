using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;
using AdminManagement.Domain.Aggregates.AdminAggregate;

namespace AdminManagement.Infrastructure.Data.Config
{
    public class AdminEntityTypeConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.FirstName).HasMaxLength(30).IsRequired(true);
            builder.Property(m => m.LastName).HasMaxLength(30).IsRequired(true);
            builder.Property(m => m.PhoneNumber).HasMaxLength(10).IsRequired(true);
            builder.Property(m => m.Email).IsRequired(true);
            builder.Property(m => m.DateOfBirth).IsRequired(true);
        }
    }
}
