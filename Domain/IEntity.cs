// <copyright file="IEntity.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace Domain
{
    using System;

    /// <summary>
    /// Интерфейс для сущностей, имеющих идентификатор.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public interface IEntity<TEntity> : IEquatable<TEntity>
        where TEntity : class, IEntity<TEntity>
    {
        /// <summary>
        /// Получает идентификатор сущности.
        /// </summary>
        Guid Id { get; }
    }
}