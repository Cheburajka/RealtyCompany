// <copyright file="ApplicationRepositoryTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using System;
    using System.Linq;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для <see cref="ApplicationRepository"/>.
    /// </summary>
    [TestFixture]
    internal sealed class ApplicationRepositoryTests
        : BaseRepositoryTests<ApplicationRepository, Application>
    {
        [SetUp]
        public void SetUp()
        {
            _ = this.DataContext.Database.EnsureCreated();
        }

        [TearDown]
        public void TearDown()
        {
            _ = this.DataContext.Database.EnsureDeleted();
        }

        [Test]
        public void Create_ValidData_Success()
        {
            // arrange
            var client = new Client("John");
            var realtor = new Realtor("Jane");
            var realtyType = new RealtyType("House");
            var realty = new Realty(realtyType, 100.0, "123 Main St", 200000.0m);
            var application = new Application(client, realtor, realty);

            // act
            _ = this.Repository.Create(application);

            // assert
            var result = this.DataContext.Find<Application>(application.Id);
            Assert.That(result, Is.EqualTo(application));
        }

        [Test]
        public void Update_ValidData_Success()
        {
            // arrange
            var client = new Client("John");
            var realtor = new Realtor("Jane");
            var realtyType = new RealtyType("House");
            var realty = new Realty(realtyType, 100.0, "123 Main St", 200000.0m);
            var application = new Application(client, realtor, realty);

            _ = this.DataContext.Add(application);
            _ = this.DataContext.SaveChanges();

            // act
            realty.Price = 250000.0m; // Изменяем цену недвижимости
            _ = this.Repository.Update(application);

            // assert
            var result = this.DataContext.Find<Application>(application.Id)?.Realty.Price;
            Assert.That(result, Is.EqualTo(250000.0m));
        }

        [Test]
        public void Delete_ValidData_Success()
        {
            // arrange
            var client = new Client("John");
            var realtor = new Realtor("Jane");
            var realtyType = new RealtyType("House");
            var realty = new Realty(realtyType, 100.0, "123 Main St", 200000.0m);
            var application = new Application(client, realtor, realty);

            _ = this.DataContext.Add(application);
            _ = this.DataContext.SaveChanges();

            // act
            _ = this.Repository.Delete(application);

            // assert
            var result = this.DataContext.Find<Application>(application.Id);
            Assert.That(result, Is.Null);
        }
    }
}