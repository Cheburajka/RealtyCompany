// <copyright file="BaseRepositoryTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using System;
    using DataAccessLayer;
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using NUnit.Framework;

    /// <summary>
    /// ������� ��� ������ ��� ������������.
    /// </summary>
    /// <typeparam name="TRepository"> ������� ��� ������������ �����������. </typeparam>
    /// <typeparam name="TEntity"> ������� ��� �������� ������������ �����������. </typeparam>
    public abstract class BaseRepositoryTests<TRepository, TEntity>
        where TRepository : BaseRepository<TEntity>
        where TEntity : class, IEntity<TEntity>
    {
        private readonly ServiceProvider serviceProvider;

        protected BaseRepositoryTests()
        {
            this.serviceProvider = new ServiceCollection()
                .AddDbContext<DataContext>(
                    builder => builder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                        .EnableDetailedErrors()
                        .EnableSensitiveDataLogging()
                        .LogTo(Console.WriteLine, LogLevel.Error))
                .AddScoped<TRepository>()
                .BuildServiceProvider();
        }

        protected DataContext DataContext
        {
            get => this.serviceProvider.GetService<DataContext>()
                ?? throw new Exception($"Cannot get {typeof(DataContext).Name}");
        }

        protected TRepository Repository
        {
            get => this.serviceProvider.GetService<TRepository>()
                ?? throw new Exception($"Cannot get {typeof(TRepository).Name}");
        }
    }
}