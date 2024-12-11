// <copyright file="RealtorRepository.cs" company="Realty">
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
    /// Репозиторий для класса <see cref="Domain.Realtor"/>.
    /// </summary>
    public sealed class RealtorRepository : BaseRepository<Realtor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RealtorRepository"/> class.
        /// Инициализирует новый экземпляр класса <see cref="RealtorRepository"/>.
        /// </summary>
        /// <param name="dataContext">Контекст доступа к данным.</param>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref name="dataContext"/> – <see langword="null"/>.
        /// </exception>
        public RealtorRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        /// <summary>
        /// Получает всех риэлторов.
        /// </summary>
        /// <returns>Риэлторы.</returns>
        public override IQueryable<Realtor> GetAll()
        {
            return this.DataContext.Realtors;
        }
    }
}