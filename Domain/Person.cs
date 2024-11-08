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
            this.Id = Guid.NewGuid();
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
        public bool Equals(Person? x, Person? y)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public int GetHashCode([DisallowNull] Person obj)
        {
            throw new NotImplementedException();
        }
    }
}