// <copyright file="RealtorConfigurationTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>
// <copyright file="RealtorConfigurationTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>
namespace DataAccessLayer.Testss
{
    using DataAccessLayer.Configurations;
    using DataAccessLayer.Testss;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для <see cref="RealtorConfiguration"/>.
    /// </summary>
    [TestFixture]
    internal sealed class RealtorConfigurationTests : BaseConfigurationTests
    {
        [TearDown]
        public void TearDown()
        {
            this.DataContext.ChangeTracker.Clear();
        }

        [Test]
        public void AddRealtorToDatabase_Success()
        {
            // arrange
            var realtor = new Realtor("Иван Иванов");

            // act
            _ = this.DataContext.Add(realtor);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // assert
            var result = this.DataContext.Find<Realtor>(realtor.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.PersonName, Is.EqualTo(realtor.PersonName));
        }
    }
}