// <copyright file="Program.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>

namespace Demo
{
    using System;
    using Domain;

    internal class Program
    {
        private static void Main(string[] args)
        {
            // Создаем тип недвижимости
            var apartmentType = new RealtyType("Apartment");

            // Создаем недвижимость
            var realty = new Realty(apartmentType, 100.0, "123 Main St", 250000.00m);

            // Создаем риэлтора
            var realtor = new Realtor("John Doe");

            // Создаем клиента
            var client = new Client("Jane Smith");

            // Выводим информацию
            Console.WriteLine("Realty Type: " + apartmentType.TypeName);
            Console.WriteLine("Realty Address: " + realty.Address);
            Console.WriteLine("Realty Price: " + realty.Price);
            Console.WriteLine("Realtor Name: " + realtor.PersonName);
            Console.WriteLine("Realtor ID: " + realtor.Id);
            Console.WriteLine("Client Name: " + client.PersonName);
            Console.WriteLine("Client ID: " + client.Id);
        }
    }
}