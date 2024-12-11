// <copyright file="Application.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>
namespace Domain
{
    using System;

    /// <summary>
    /// Класс, представляющий заявку на сделку с недвижимостью.
    /// </summary>
    public sealed class Application : Entity<Application>, IEquatable<Application>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        /// <param name="client">Клиент.</param>
        /// <param name="realtor">Риэлтор.</param>
        /// <param name="realty">Недвижимость.</param>
        public Application(Client client, Realtor realtor, Realty realty)
        {
            this.Id = Guid.Empty;
            this.Client = client ?? throw new ArgumentNullException(nameof(client));
            this.Realtor = realtor ?? throw new ArgumentNullException(nameof(realtor));
            this.Realty = realty ?? throw new ArgumentNullException(nameof(realty));
        }

        [Obsolete("For ORM only")]
        private Application()
        {
        }

        /// <summary>
        /// Получает идентификатор заявки.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Получает клиента.
        /// </summary>
        public Client Client { get; }

        /// <summary>
        /// Получает риэлтора.
        /// </summary>
        public Realtor Realtor { get; }

        /// <summary>
        /// Получает недвижимость.
        /// </summary>
        public Realty Realty { get; }

        /// <inheritdoc/>
        public bool Equals(Application? other)
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
                   this.Client.Equals(other.Client) &&
                   this.Realtor.Equals(other.Realtor) &&
                   this.Realty.Equals(other.Realty);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Application);
        }

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(this.Id, this.Client, this.Realtor, this.Realty);
    }
}