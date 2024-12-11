// <copyright file="RealtyTypeRepositoryTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using System;
    using System.Linq;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для <see cref="RealtyTypeRepository"/>.
    /// </summary>
    [TestFixture]
    internal sealed class RealtyTypeRepositoryTests
        : BaseRepositoryTests<RealtyTypeRepository, RealtyType>
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

            // act
            _ = this.Repository.Create(realtyType);

            // assert
            var result = this.DataContext.Find<RealtyType>(realtyType.Id);
            Assert.That(result, Is.EqualTo(realtyType));
        }

        [Test]
        public void Delete_ValidData_Success()
        {
            // arrange
            var realtyType = new RealtyType("House");
            _ = this.DataContext.Add(realtyType);
            _ = this.DataContext.SaveChanges();

            // act
            _ = this.Repository.Delete(realtyType);

            // assert
            var result = this.DataContext.Find<RealtyType>(realtyType.Id);
            Assert.That(result, Is.Null);
        }
    }
}