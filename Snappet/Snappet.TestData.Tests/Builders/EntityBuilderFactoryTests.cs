using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snappet.Data.Entities;
using Snappet.TestData.Builders;
using Snappet.TestData.Entities;

namespace Snappet.TestData.Tests.Builders
{
    [TestClass]
    public class EntityBuilderFactoryTests
    {
        [TestMethod]
        public void GetEntityBuilder_KnownEntityBuilder_ReturnsKnownEntityBuilder()
        {
            var factory = new EntityBuilderFactory();
            var builder = factory.GetEntityBuilder<ExerciseRecord, ExerciseStatsBySubject>();
            Assert.IsNotNull(builder);
        }

        [TestMethod]
        public void GetEntityBuilder_UnKnownEntityBuilder_ReturnsNull()
        {
            var factory = new EntityBuilderFactory();
            var builder = factory.GetEntityBuilder<ExerciseRecord, object>();
            Assert.IsNull(builder);
        }
    }
}
