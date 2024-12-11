// <copyright file="RealtyTypeConfigurationTests.cs" company="Realty">
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
    /// Тесты для <see cref="RealtyTypeConfiguration"/>.
    /// </summary>
    [TestFixture]
    internal sealed class RealtyTypeConfigurationTests : BaseConfigurationTests
    {
        [TearDown]
        public void TearDown()
        {
            this.DataContext.ChangeTracker.Clear();
        }

        [Test]
        public void RealtyType_Configuration_Should_Set_MaxLength_For_TypeName()
        {
            // Arrange
            var longTypeName = new string('a', 101); // 101 characters, which exceeds the max length
            var realtyType = CreateRealtyType(longTypeName);

            // Act & Assert
            Assert.Throws<DbUpdateException>(() =>
            {
                this.DataContext.RealtyTypes.Add(realtyType);
                this.DataContext.SaveChanges();
            });
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