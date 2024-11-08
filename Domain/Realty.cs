// <copyright file="Realty.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>
namespace Domain
{
    using System;
    using Staff;

    /// <summary>
    /// Класс, представляющий недвижимость.
    /// </summary>
    public sealed class Realty : IEquatable<Realty>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Realty"/> class.
        /// </summary>
        /// <param name="realtyType">Тип недвижимости.</param>
        /// <param name="square">Площадь.</param>
        /// <param name="address">Адрес.</param>
        /// <param name="price">Цена.</param>
        public Realty(RealtyType realtyType, double square, string address, decimal price)
        {
            this.Id = Guid.NewGuid();

            if (realtyType is null)
            {
                throw new ArgumentNullException(nameof(realtyType), "RealtyType не может быть null.");
            }

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(square);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

            this.RealtyType = realtyType;
            this.Square = square;
            this.Address = address.TrimOrNull() ?? throw new ArgumentNullException(nameof(address));
            this.Price = price;
        }

        [Obsolete("For ORM only")]
        private Realty()
        {
        }

        /// <summary>
        /// Получает идентификатор недвижимости.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Получает тип недвижимости.
        /// </summary>
        public RealtyType RealtyType { get; }

        /// <summary>
        /// Получает площадь недвижимости.
        /// </summary>
        public double Square { get; }

        /// <summary>
        /// Получает адрес недвижимости.
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Получает или задает цену недвижимости.
        /// </summary>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public bool Equals(Realty? other)
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
                   this.RealtyType.Equals(other.RealtyType) &&
                   this.Square == other.Square &&
                   this.Address == other.Address &&
                   this.Price == other.Price;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Realty);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(this.Id, this.RealtyType, this.Square, this.Address, this.Price);
    }
}