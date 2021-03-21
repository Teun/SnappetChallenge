using NUnit.Framework;

namespace Snappet.Logic.UnitTests.Database
{
    [TestFixture]
    public class DatabaseContextDapper
    {
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase(" ")]
        [Test]
        public void Constructor_WhenPassInvalidConnectionString_ThrowsArgumentNullException(string cns)
        {
            Assert.That(() => {
                new Logic.Database.DatabaseContextDapper(cns);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void Constructor_WhenPassValidConnectionString_ReturnObject()
        {
            var rst = new Logic.Database.DatabaseContextDapper("connectionString");
            Assert.That(rst, Is.Not.Null);
            Assert.That(rst, Is.TypeOf<Logic.Database.DatabaseContextDapper>());
        }

    }
}
