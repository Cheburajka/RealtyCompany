namespace DataAccessLayer.Tests
{
    using DataAccessLayer.Configurations;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для <see cref="ClientConfiguration"/>.
    /// </summary>
    [TestFixture]
    internal sealed class ClientConfigurationTests : BaseConfigurationTests
    {
        [TearDown]
        public void TearDown()
        {
            this.DataContext.ChangeTracker.Clear();
        }

        [Test]
        public void AddClientToDatabase_Success()
        {
            // arrange
            var client = new Client("Иван Ивановп");

            // act
            _ = this.DataContext.Add(client);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // assert
            var result = this.DataContext.Find<Client>(client.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.PersonName, Is.EqualTo(client.PersonName));
        }
    }
}