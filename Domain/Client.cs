// <copyright file="Client.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace Domain
{
    using System;
    using System.Xml.Linq;

    /// <summary>
    /// Класс, представляющий клиента.
    /// </summary>
    public class Client : Person<Client>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="name">Имя клиента.</param>
         public Client(string name)
           : base(name)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Client"/>.
        /// </summary>
        [Obsolete("For ORM only", true)]
        private Client()
            : base(string.Empty)
        {
        }

    }
}