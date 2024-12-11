// <copyright file="ApplicationConfigurationTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>
namespace DataAccessLayer.Testss
{
    using DataAccessLayer.Testss;
    using Domain;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Тесты для <see cref="ApplicationConfiguration"/>.
    /// </summary>
    [TestFixture]
    internal sealed class ApplicationConfigurationTests : BaseConfigurationTests
    {
        [TearDown]
        public void TearDown()
        {
            this.DataContext.ChangeTracker.Clear();
        }

        [Test]
        public void Application_Configuration_Should_Set_Primary_Key()
        {
            // Arrange
            var application = CreateApplication();

            // Act
            this.DataContext.Applications.Add(application);
            this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // Assert
            var result = this.DataContext.Applications.Find(application.Id);
            Assert.That(result, Is.Not.Null);
        }

        private static Application CreateApplication(Client client = null, Realtor realtor = null, Realty realty = null)
        {
            var application = (Application)Activator.CreateInstance(typeof(Application), nonPublic: true);

            var idProperty = typeof(Application).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            if (idProperty != null && idProperty.CanWrite)
            {
                idProperty.SetValue(application, 1);
            }

            var clientProperty = typeof(Application).GetProperty("Client", BindingFlags.Public | BindingFlags.Instance);
            if (clientProperty != null && clientProperty.CanWrite)
            {
                clientProperty.SetValue(application, client);
            }

            var realtorProperty = typeof(Application).GetProperty("Realtor", BindingFlags.Public | BindingFlags.Instance);
            if (realtorProperty != null && realtorProperty.CanWrite)
            {
                realtorProperty.SetValue(application, realtor);
            }

            var realtyProperty = typeof(Application).GetProperty("Realty", BindingFlags.Public | BindingFlags.Instance);
            if (realtyProperty != null && realtyProperty.CanWrite)
            {
                realtyProperty.SetValue(application, realty);
            }

            return application;
        }

        private static Client CreateClient(string name)
        {
            var client = (Client)Activator.CreateInstance(typeof(Client), nonPublic: true);

            var idProperty = typeof(Client).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            if (idProperty != null && idProperty.CanWrite)
            {
                idProperty.SetValue(client, 1);
            }

            var nameProperty = typeof(Client).GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
            if (nameProperty != null && nameProperty.CanWrite)
            {
                nameProperty.SetValue(client, name);
            }

            return client;
        }

        private static Realtor CreateRealtor(string name)
        {
            var realtor = (Realtor)Activator.CreateInstance(typeof(Realtor), nonPublic: true);

            var idProperty = typeof(Realtor).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            if (idProperty != null && idProperty.CanWrite)
            {
                idProperty.SetValue(realtor, 1);
            }

            var nameProperty = typeof(Realtor).GetProperty("Name", BindingFlags.Public | BindingFlags.Instance);
            if (nameProperty != null && nameProperty.CanWrite)
            {
                nameProperty.SetValue(realtor, name);
            }

            return realtor;
        }

        private static Realty CreateRealty(RealtyType realtyType, string address, decimal price, double square)
        {
            var realty = (Realty)Activator.CreateInstance(typeof(Realty), nonPublic: true);

            var idProperty = typeof(Realty).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            if (idProperty != null && idProperty.CanWrite)
            {
                idProperty.SetValue(realty, 1);
            }

            var addressProperty = typeof(Realty).GetProperty("Address", BindingFlags.Public | BindingFlags.Instance);
            if (addressProperty != null && addressProperty.CanWrite)
            {
                addressProperty.SetValue(realty, address);
            }

            var priceProperty = typeof(Realty).GetProperty("Price", BindingFlags.Public | BindingFlags.Instance);
            if (priceProperty != null && priceProperty.CanWrite)
            {
                priceProperty.SetValue(realty, price);
            }

            var squareProperty = typeof(Realty).GetProperty("Square", BindingFlags.Public | BindingFlags.Instance);
            if (squareProperty != null && squareProperty.CanWrite)
            {
                squareProperty.SetValue(realty, square);
            }

            var realtyTypeProperty = typeof(Realty).GetProperty("RealtyType", BindingFlags.Public | BindingFlags.Instance);
            if (realtyTypeProperty != null && realtyTypeProperty.CanWrite)
            {
                realtyTypeProperty.SetValue(realty, realtyType);
            }

            return realty;
        }

        private static RealtyType CreateRealtyType(string typeName)
        {
            var realtyType = (RealtyType)Activator.CreateInstance(typeof(RealtyType), nonPublic: true);

            var idProperty = typeof(RealtyType).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);
            if (idProperty != null && idProperty.CanWrite)
            {
                idProperty.SetValue(realtyType, 1);
            }

            var typeNameProperty = typeof(RealtyType).GetProperty("TypeName", BindingFlags.Public | BindingFlags.Instance);
            if (typeNameProperty != null && typeNameProperty.CanWrite)
            {
                typeNameProperty.SetValue(realtyType, typeName);
            }

            return realtyType;
        }
    }
}