using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;

namespace DataAccessLayer.Tests
{
    /// <summary>
    /// ������� ��� ��� ���������� ��������� ������ ������������ (<see cref="IEntityTypeConfiguration{TEntity}"/>).
    /// </summary>
    internal abstract class BaseConfigurationTests
    {
        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="BaseConfigurationTests"/>.
        /// </summary>
        /// <param name="minimumLogLevel">����������� ������� ���������� ���������.</param>
        /// <exception cref="Exception">� ������ ������������� ����������/��������� ��������� ������� � ������.</exception>
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
        /// �������� ������� � ������.
        /// </summary>
        protected DataContext DataContext { get; }
    }
}