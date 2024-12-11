// <copyright file="ApplicationRepository.cs" company="Realty">
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
    /// Репозиторий для класса <see cref="Domain.Application"/>.
    /// </summary>
    public sealed class ApplicationRepository : BaseRepository<Application>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRepository"/> class.
        /// Инициализирует новый экземпляр класса <see cref="ApplicationRepository"/>.
        /// </summary>
        /// <param name="dataContext">Контекст доступа к данным.</param>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref name="dataContext"/> – <see langword="null"/>.
        /// </exception>
        public ApplicationRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        /// <summary>
        /// Получает все заявки.
        /// </summary>
        /// <returns>Заявки.</returns>
        public override IQueryable<Application> GetAll()
        {
            return this.DataContext.Applications
                .Include(application => application.Client)
                .Include(application => application.Realtor)
                .Include(application => application.Realty);
        }
    }
}