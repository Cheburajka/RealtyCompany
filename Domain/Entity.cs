// <copyright file="Entity.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace Domain
{
    using System;

    /// <summary>
    /// Базовая сущность.
    /// </summary>
    /// <typeparam name="TEntity"> Тип конкретной сущности. </typeparam>
    public abstract class Entity<TEntity> : IEntity<TEntity>
        where TEntity : class, IEntity<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity{TEntity}"/> class.
        /// Инициализирует новый экземпляр класса <see cref="Entity{TEntity}"/>.
        /// </summary>
        protected Entity() => this.Id = Guid.Empty;

        /// <inheritdoc cref="IEntity{TEntity}.Id"/>
        public virtual Guid Id { get; protected set; }

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString() => $"[{this.Id}]";

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object? obj)
        {
            return ReferenceEquals(this, obj)
                || (obj is TEntity entity && this.Equals(entity));
        }

        /// <inheritdoc/>
        public virtual bool Equals(TEntity? other)
        {
            return other is not null
                && this.GetType() == other.GetType()
                && this.Id == other.Id;
        }

        /// <inheritdoc/>
        // @NOTE: В случае проблемы заменить на object.GetHashCode().
        public override int GetHashCode() => this.Id.GetHashCode();
    }
}