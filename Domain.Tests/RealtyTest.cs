// <copyright file="RealtyTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace DomainTests
{
    using System;
    using NUnit.Framework;
    using Domain;

    [TestFixture]
    public class RealtyTests
    {
        private RealtyType _realtyType;
        private double _square;
        private string _address;
        private decimal _price;

        [SetUp]
        public void Setup()
        {
            _realtyType = new RealtyType("House");
            _square = 100.0;
            _address = "123 Main St";
            _price = 500000.0m;
        }

        [Test]
        public void Constructor_NullRealtyType_ThrowsArgumentNullException()
        {
            // Arrange
            RealtyType realtyType = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Realty(realtyType, _square, _address, _price));
        }

        [Test]
        public void Constructor_NegativeSquare_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            double square = -100.0;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Realty(_realtyType, square, _address, _price));
        }

        [Test]
        public void Constructor_NegativePrice_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            decimal price = -500000.0m;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Realty(_realtyType, _square, _address, price));
        }

        [Test]
        public void Constructor_NullAddress_ThrowsArgumentNullException()
        {
            // Arrange
            string address = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Realty(_realtyType, _square, address, _price));
        }

        [Test]
        public void Constructor_EmptyAddress_ThrowsArgumentNullException()
        {
            // Arrange
            string address = string.Empty;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Realty(_realtyType, _square, address, _price));
        }
    }
}