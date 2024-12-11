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
        private static readonly string ConnectionString = "User ID=postgres; Password=1234; Host=localhost; Port=5432; Database=RealtyCompany1;";

        private static readonly DbContextOptions<DataContext> Options = new DbContextOptionsBuilder<DataContext>()
            .UseNpgsql(ConnectionString)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging()
            .LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Error)
            .Options;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DataContext"/>.
        /// </summary>
        public DataContext()
            : this(Options)
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
        public DbSet<Client> Clients { get; init; }

        /// <summary>
        /// </summary>
        public DbSet<Realtor> Realtors { get; init; }

        /// <summary>
        /// </summary>
        public DbSet<Realty> Realties { get; init; }

        /// <summary>
        /// </summary>
        public DbSet<RealtyType> RealtyTypes { get; init; }

        /// <summary>
        /// </summary>
        public DbSet<Application> Applications { get; init; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}