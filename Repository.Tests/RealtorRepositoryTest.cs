// <copyright file="RealtorRepositoryTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using System;
    using System.Linq;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для <see cref="RealtorRepository"/>.
    /// </summary>
    [TestFixture]
    internal sealed class RealtorRepositoryTests
        : BaseRepositoryTests<RealtorRepository, Realtor>
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
            var realtor = new Realtor("Jane");

            // act
            _ = this.Repository.Create(realtor);

            // assert
            var result = this.DataContext.Find<Realtor>(realtor.Id);
            Assert.That(result, Is.EqualTo(realtor));
        }

        [Test]
        public void Delete_ValidData_Success()
        {
            // arrange
            var realtor = new Realtor("Jane");
            _ = this.DataContext.Add(realtor);
            _ = this.DataContext.SaveChanges();

            // act
            _ = this.Repository.Delete(realtor);

            // assert
            var result = this.DataContext.Find<Realtor>(realtor.Id);
            Assert.That(result, Is.Null);
        }
    }
}