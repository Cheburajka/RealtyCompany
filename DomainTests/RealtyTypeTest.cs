// <copyright file="RealtyTypeTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace DomainTests
{
    using NUnit.Framework;
    using System;
    using Domain;

    [TestFixture]
    public class RealtyTypeTests
    {
        [Test]
        public void Constructor_NullName_ThrowsArgumentNullException()
        {
            // Arrange
            string name = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new RealtyType(name));
        }

        [Test]
        public void Constructor_EmptyName_ThrowsArgumentNullException()
        {
            // Arrange
            string name = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new RealtyType(name));
        }

        [Test]
        public void Equals_SameInstance_ReturnsTrue()
        {
            // Arrange
            var realtyType = new RealtyType("Apartment");

            // Act
            var result = realtyType.Equals(realtyType);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_DifferentInstancesWithSameName_ReturnsTrue()
        {
            // Arrange
            var realtyType1 = new RealtyType("Apartment");
            var realtyType2 = new RealtyType("Apartment");

            // Act
            var result = realtyType1.Equals(realtyType2);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_DifferentInstancesWithDifferentName_ReturnsFalse()
        {
            // Arrange
            var realtyType1 = new RealtyType("Apartment");
            var realtyType2 = new RealtyType("House");

            // Act
            var result = realtyType1.Equals(realtyType2);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_NullInstance_ReturnsFalse()
        {
            // Arrange
            var realtyType = new RealtyType("Apartment");

            // Act
            var result = realtyType.Equals(null);

            // Assert
            Assert.IsFalse(result);
        }
    }
}