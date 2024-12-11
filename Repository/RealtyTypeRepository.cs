// <copyright file="RealtyTypeRepository.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace Repository
{
    using System;
    using System.Linq;
    using DataAccessLayer;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Репозиторий для класса <see cref="Domain.RealtyType"/>.
    /// </summary>
    public sealed class RealtyTypeRepository : BaseRepository<RealtyType>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RealtyTypeRepository"/>.
        /// </summary>
        /// <param name="dataContext">Контекст доступа к данным.</param>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref name="dataContext"/> – <see langword="null"/>.
        /// </exception>
        public RealtyTypeRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        /// <summary>
        /// Получает все типы недвижимости.
        /// </summary>
        /// <returns>Типы недвижимости.</returns>
        public override IQueryable<RealtyType> GetAll()
        {
            return this.DataContext.RealtyTypes;
        }
    }
}