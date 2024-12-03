// <copyright file="ApplicationConfiguration.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain;

    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasOne(a => a.Client).WithMany().HasForeignKey("ClientId");
            builder.HasOne(a => a.Realtor).WithMany().HasForeignKey("RealtorId");
            builder.HasOne(a => a.Realty).WithMany().HasForeignKey("RealtyId");
        }
    }
}