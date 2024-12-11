// <copyright file="RealtorConfiguration.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace DataAccessLayer.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain;

    public class RealtorConfiguration : IEntityTypeConfiguration<Realtor>
    {
        public void Configure(EntityTypeBuilder<Realtor> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.PersonName).IsRequired().HasMaxLength(100);
        }
    }
}