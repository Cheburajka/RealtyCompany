// <copyright file="Program.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

using DataAccessLayer;
using Domain;

namespace Demo
{
    using System;
    using Domain;

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                // Создаём нового клиента
                var client = new Client("Иван Иванов");

                // Добавляем клиента в базу
                context.Clients.Add(client);

                // Сохраняем изменения
                context.SaveChanges();

                Console.WriteLine($"Клиент добавлен с ID: {client.Id}");
            }
        }
    }
}