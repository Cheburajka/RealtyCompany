// <copyright file="Realtor.cs" company="Realty">
// Copyright (c) Realty. All rights reserved.
// </copyright>
namespace Domain
{
    using System;

    /// <summary>
    /// Класс, представляющий риэлтора.
    /// </summary>
    public class Realtor : Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Realtor"/> class.
        /// </summary>
        /// <param name="name">Имя риэлтора.</param>
        public Realtor(string name)
            : base(name)
        {
        }
    }
}