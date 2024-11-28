// <copyright file="RealtyConfiguration.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain;

    public class RealtyConfiguration : IEntityTypeConfiguration<Realty>
    {
        public void Configure(EntityTypeBuilder<Realty> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Square).IsRequired();
            builder.Property(r => r.Address).IsRequired().HasMaxLength(200);
            builder.Property(r => r.Price).IsRequired();
            builder.HasOne(r => r.RealtyType).WithMany().HasForeignKey("RealtyTypeId");
        }
    }
}