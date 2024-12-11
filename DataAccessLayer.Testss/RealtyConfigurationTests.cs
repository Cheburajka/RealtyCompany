// <copyright file="RealtyConfigurationTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>
namespace DataAccessLayer.Testss
{
    using DataAccessLayer.Configurations;
    using Domain;
    using NUnit.Framework;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Тесты для <see cref="RealtyConfiguration"/>.
    /// </summary>
    [TestFixture]
    internal sealed class RealtyConfigurationTests : BaseConfigurationTests
    {
        [TearDown]
        public void TearDown()
        {
            this.DataContext.ChangeTracker.Clear();
        }

        [Test]
        public void AddRealtyToDatabase_Success()
        {
            // arrange
            var realtyType = new RealtyType("House");
            var realty = new Realty(realtyType, 100.0, "123 Main St", 500000.0m);

            // Добавляем RealtyType в контекст данных
            this.DataContext.RealtyTypes.Add(realtyType);
            this.DataContext.SaveChanges();

            // act
            this.DataContext.Realties.Add(realty);
            this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // assert
            var result = this.DataContext.Realties
                .Include(r => r.RealtyType)
                .FirstOrDefault(r => r.Id == realty.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.RealtyType, Is.EqualTo(realty.RealtyType));
            Assert.That(result!.Square, Is.EqualTo(realty.Square));
            Assert.That(result!.Address, Is.EqualTo(realty.Address));
            Assert.That(result!.Price, Is.EqualTo(realty.Price));
        }
    }
}