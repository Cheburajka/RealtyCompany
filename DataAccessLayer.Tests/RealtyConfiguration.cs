namespace DataAccessLayer.Tests
{
    using DataAccessLayer.Configurations;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты для <see cref="RealtyConfiguration"/>.
    /// </summary>
    [TestFixture]
    internal sealed class RealtyConfigurationTests : BaseConfigurationTests
    {
        [TearDown]
        public void TearDown()
        {
            this.DataContext.ChangeTracker.Clear();
        }

        [Test]
        public void AddRealtyToDatabase_Success()
        {
            // arrange
            var realtyType = new RealtyType("House");
            var realty = new Realty(realtyType, 100.0, "123 Main St", 500000.0m);

            // act
            _ = this.DataContext.Add(realty);
            _ = this.DataContext.SaveChanges();
            this.DataContext.ChangeTracker.Clear();

            // assert
            var result = this.DataContext.Find<Realty>(realty.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.RealtyType, Is.EqualTo(realty.RealtyType));
            Assert.That(result!.Square, Is.EqualTo(realty.Square));
            Assert.That(result!.Address, Is.EqualTo(realty.Address));
            Assert.That(result!.Price, Is.EqualTo(realty.Price));
        }
    }
}