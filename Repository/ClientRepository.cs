// <copyright file="ClientRepository.cs" company="Realty">
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
    /// Репозиторий для класса <see cref="Domain.Client"/>.
    /// </summary>
    public sealed class ClientRepository : BaseRepository<Client>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientRepository"/> class.
        /// Инициализирует новый экземпляр класса <see cref="ClientRepository"/>.
        /// </summary>
        /// <param name="dataContext">Контекст доступа к данным.</param>
        /// <exception cref="ArgumentNullException">
        /// В случае если <paramref name="dataContext"/> – <see langword="null"/>.
        /// </exception>
        public ClientRepository(DataContext dataContext)
            : base(dataContext)
        {
        }

        /// <summary>
        /// Получает всех клиентов.
        /// </summary>
        /// <returns>Клиенты.</returns>
        public override IQueryable<Client> GetAll()
        {
            return this.DataContext.Clients;
        }
    }
}