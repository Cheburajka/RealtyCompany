// <copyright file="RealtyRepository.cs" company="Realty">
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
    /// Репозиторий для класса <see cref="Domain.Realty"/>.
    /// </summary>
    public sealed class RealtyRepository : BaseRepository<Realty>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RealtyRepository"/>.
        /// </summary>
        /// <param name="dataContext">Контекст доступа к данным.</param>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref name="dataContext"/> – <see langword="null"/>.
        /// </exception>
        public RealtyRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        /// <summary>
        /// Получает все объекты недвижимости.
        /// </summary>
        /// <returns>Объекты недвижимости.</returns>
        public override IQueryable<Realty> GetAll()
        {
            return this.DataContext.Realties
                .Include(realty => realty.RealtyType);
        }
    }
}