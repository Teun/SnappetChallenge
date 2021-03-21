using Moq;
using NUnit.Framework;

namespace Snappet.Logic.UnitTests.Database.ContextMethods
{
    [TestFixture]
    public class SP_Teacher_Login
    {
        Mock<ORM.Dapper.Features.ISQLExecuter> sqlExecuter;
        Logic.Database.DatabaseContextDapper ctx;
        Models.Database.StoredProcedures.dbo.SP_Teacher_Login.Inputs inputData;

        [SetUp]
        public void Setup()
        {
            sqlExecuter = new Mock<ORM.Dapper.Features.ISQLExecuter>();
            ctx = new Logic.Database.DatabaseContextDapper("connectionString", sqlExecuter.Object);
            inputData = new Models.Database.StoredProcedures.dbo.SP_Teacher_Login.Inputs()
            {
                Email = "Email@site.com",
                Password = "Password"
            };
        }

        [Test]
        public void Call_WhenPassNullData_ShouldTrowsArgumentNullException()
        {
            Assert.That(() =>
            {
                ctx.SP_Teacher_Login(null);
            }, Throws.ArgumentNullException);
        }

        [Test]
        public void Call_WhenPassInfo_ShouldExecuteSQL()
        {
            ctx.SP_Teacher_Login(inputData);

            sqlExecuter.Verify(s =>
                s.Query<Models.Database.StoredProcedures.dbo.SP_Teacher_Login.Outputs>(
                    It.IsAny<string>(),
                    It.IsAny<object>(),
                    System.Data.CommandType.StoredProcedure)
            );
        }

        [Test]
        public void Call_WhenPassInfo_ShouldReturnDBResultObject()
        {
            var rst = ctx.SP_Teacher_Login(inputData);

            Assert.That(rst, Is.Not.Null);
            Assert.That(rst, Is.TypeOf<Models.Database.DBResult>());
        }
    }
}
