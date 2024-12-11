// <copyright file="RealtyTypeConfiguration.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain;

    public class RealtyTypeConfiguration : IEntityTypeConfiguration<RealtyType>
    {
        public void Configure(EntityTypeBuilder<RealtyType> builder)
        {
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.TypeName).IsRequired().HasMaxLength(100);
        }
    }
}