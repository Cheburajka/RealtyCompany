// <copyright file="Client.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>
namespace Domain
{
    using System;

    /// <summary>
    /// Класс, представляющий клиента.
    /// </summary>
    public class Client : Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="name">Имя клиента.</param>
        public Client(string name)
            : base(name)
        {
        }
    }
}