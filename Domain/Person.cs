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
    public abstract class Person<TPerson> : IEquatable<TPerson>
        where TPerson : Person<TPerson>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person{TPerson}"/> class.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        protected Person(string name)
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
        public bool Equals(TPerson? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Id == other.Id &&
                   string.Equals(this.PersonName, other.PersonName, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as TPerson);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, StringComparer.OrdinalIgnoreCase.GetHashCode(this.PersonName));
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.PersonName} (ID: {this.Id})";
        }
    }
}