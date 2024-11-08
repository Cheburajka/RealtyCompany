// <copyright file="PersonTests.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace DomainTests
{
    using System;
    using NUnit.Framework;
    using Domain;

    [TestFixture]
    public class PersonTests
    {
        [Test]
        [TestCase(typeof(Realtor))]
        [TestCase(typeof(Client))]
        public void Constructor_NullName_ThrowsArgumentNullException(Type personType)
        {
            // Arrange
            string name = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Realtor(name));
            Assert.Throws<ArgumentNullException>(() => new Client(name));
        }

        [Test]
        [TestCase(typeof(Realtor), "Jane Smith")]
        [TestCase(typeof(Client), "Alice Johnson")]
        public void Constructor_ValidName_InitializesPropertiesCorrectly(Type personType, string name)
        {
            // Act
            Person person = (Person)Activator.CreateInstance(personType, name);

            // Assert
            Assert.AreNotEqual(Guid.Empty, person.Id);
            Assert.AreEqual(name, person.PersonName);
        }
    }
}