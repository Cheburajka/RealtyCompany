using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;

namespace DataAccessLayer.Tests
{
    /// <summary>
    /// Базовый тип для реализации модульных тестов конфигураций (<see cref="IEntityTypeConfiguration{TEntity}"/>).
    /// </summary>
    internal abstract class BaseConfigurationTests
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BaseConfigurationTests"/>.
        /// </summary>
        /// <param name="minimumLogLevel">Минимальный уровень логируемых сообщений.</param>
        /// <exception cref="Exception">В случае невозможности построения/получения контекста доступа к данным.</exception>
        protected BaseConfigurationTests(LogLevel minimumLogLevel = LogLevel.Debug)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<DataContext>(
                    options => options
                        .UseInMemoryDatabase($"InMemoryDB_{Guid.NewGuid()}")
                        .EnableDetailedErrors()
                        .EnableSensitiveDataLogging()
                        .LogTo(Console.WriteLine, minimumLogLevel))
                .BuildServiceProvider();

            this.DataContext = serviceProvider.GetService<DataContext>()
                ?? throw new Exception($"Cannot get {typeof(DataContext).FullName} from DI");
        }

        /// <summary>
        /// Контекст доступа к данным.
        /// </summary>
        protected DataContext DataContext { get; }
    }
}