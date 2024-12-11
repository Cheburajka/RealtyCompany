// <copyright file="ClientRepositoryTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace Repository.Tests
{
    using System;
    using System.Linq;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Модульные тесты для <see cref="ClientRepository"/>.
    /// </summary>
    [TestFixture]
    internal sealed class ClientRepositoryTests
        : BaseRepositoryTests<ClientRepository, Client>
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

            // act
            _ = this.Repository.Create(client);

            // assert
            var result = this.DataContext.Find<Client>(client.Id);
            Assert.That(result, Is.EqualTo(client));
        }

        [Test]
        public void Delete_ValidData_Success()
        {
            // arrange
            var client = new Client("John");
            _ = this.DataContext.Add(client);
            _ = this.DataContext.SaveChanges();

            // act
            _ = this.Repository.Delete(client);

            // assert
            var result = this.DataContext.Find<Client>(client.Id);
            Assert.That(result, Is.Null);
        }
    }
}