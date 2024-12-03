// <copyright file="DataContext.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace DataAccessLayer
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    public sealed class DataContext : DbContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DataContext"/>.
        /// </summary>
        public DataContext()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DataContext"/>.
        /// </summary>
        /// <param name="options"> Опции настройки контекста. </param>
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// </summary>
        public DbSet<Realtor> Realtors { get; set; }

        /// <summary>
        /// </summary>
        public DbSet<Realty> Realties { get; set; }

        /// <summary>
        /// </summary>
        public DbSet<RealtyType> RealtyTypes { get; set; }

        /// <summary>
        /// </summary>
        public DbSet<Application> Applications { get; set; }



        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres; Password=1234; Host=localhost; Port=5432; Database=RealtyCompany1;");
        }

    }
}