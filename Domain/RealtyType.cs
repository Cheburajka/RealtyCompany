// <copyright file="RealtyType.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using Staff;

    /// <summary>
    /// Класс, представляющий тип недвижимости.
    /// </summary>
    public sealed class RealtyType : IEquatable<RealtyType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RealtyType"/> class.
        /// </summary>
        /// <param name="name">Имя типа недвижимости.</param>
        public RealtyType(string name)
        {
            this.Id = Guid.NewGuid();
            this.TypeName = name.TrimOrNull() ?? throw new ArgumentNullException(nameof(name));
        }

        [Obsolete("For ORM only")]
        private RealtyType()
        {
        }

        /// <summary>
        /// Получает идентификатор типа недвижимости.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Получает имя типа недвижимости.
        /// </summary>
        public string TypeName { get; }

        /// <inheritdoc/>
        public bool Equals(RealtyType? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.TypeName == other.TypeName;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as RealtyType);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(this.TypeName);
    }
}