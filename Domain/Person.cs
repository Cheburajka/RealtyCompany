// <copyright file="Person.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>
namespace Domain
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Абстрактный класс, представляющий человека.
    /// </summary>
    public abstract class Person : IEqualityComparer<Person>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        public Person(string name)
        {
            this.Id = Guid.Empty;
            this.PersonName = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        /// Получает идентификатор человека.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Получает имя человека.
        /// </summary>
        public string PersonName { get; }

        /// <inheritdoc/>
        public bool Equals(Person? firstPerson, Person? secondPerson)
        {
            if (firstPerson == null && secondPerson == null)
            {
                return true;
            }

            if (firstPerson == null || secondPerson == null)
            {
                return false;
            }

            if (firstPerson.Id != Guid.Empty && secondPerson.Id != Guid.Empty)
            {
                return firstPerson.Id == secondPerson.Id;
            }

            return string.Equals(firstPerson.PersonName, secondPerson.PersonName, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public int GetHashCode([DisallowNull] Person person)
        {
            ArgumentNullException.ThrowIfNull(person);

            if (person.Id != Guid.Empty)
            {
                return person.Id.GetHashCode();
            }

            return StringComparer.OrdinalIgnoreCase.GetHashCode(person.PersonName);
        }
    }
}