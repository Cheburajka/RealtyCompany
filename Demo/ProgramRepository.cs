// <copyright file="Program.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

using DataAccessLayer;
using Domain;
using Repository;

namespace Demo
{
    using System;

    class Programs
    {
        static void Main(string[] args)
        {
            // Создаём контекст данных
            using (var context = new DataContext())
            {
                // Создаём репозиторий для клиентов
                var clientRepository = new ClientRepository(context);

                // Создаём нового клиента
                var client = new Client("Fff Петров");

                // Добавляем клиента в базу через репозиторий
                clientRepository.Create(client);

                Console.WriteLine($"Клиент добавлен с ID: {client.Id}");
            }
        }
    }
}