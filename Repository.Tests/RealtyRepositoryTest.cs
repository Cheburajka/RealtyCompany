// <copyright file="RealtyRepositoryTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using System;
    using System.Linq;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для <see cref="RealtyRepository"/>.
    /// </summary>
    [TestFixture]
    internal sealed class RealtyRepositoryTests
        : BaseRepositoryTests<RealtyRepository, Realty>
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
            var realtyType = new RealtyType("House");
            var realty = new Realty(realtyType, 100.0, "123 Main St", 200000.0m);

            // act
            _ = this.Repository.Create(realty);

            // assert
            var result = this.DataContext.Find<Realty>(realty.Id);
            Assert.That(result, Is.EqualTo(realty));
        }

        [Test]
        public void Delete_ValidData_Success()
        {
            // arrange
            var realtyType = new RealtyType("House");
            var realty = new Realty(realtyType, 100.0, "123 Main St", 200000.0m);
            _ = this.DataContext.Add(realty);
            _ = this.DataContext.SaveChanges();

            // act
            _ = this.Repository.Delete(realty);

            // assert
            var result = this.DataContext.Find<Realty>(realty.Id);
            Assert.That(result, Is.Null);
        }
    }
}