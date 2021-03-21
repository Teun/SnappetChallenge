using Moq;
using NUnit.Framework;
using Snappet.Models.Database.StoredProcedures.dbo;

namespace Snappet.Logic.UnitTests.Security
{
    [TestFixture]
    public class Teacher
    {
        Mock<Logic.Database.IDatabaseContext> ctx = new Mock<Logic.Database.IDatabaseContext>();
        Mock<AutoMapper.IMapper> mapper = new Mock<AutoMapper.IMapper>();
        Logic.Security.Teacher teacher = new Logic.Security.Teacher();
        Logic.Security.User user;
        SP_Teacher_Login.Outputs dbResult;
        string key = "The key for generate JWT.";
        string issuer = "https://snappet.org";


        [SetUp]
        public void Setup()
        {
            dbResult = new SP_Teacher_Login.Outputs()
            {
                Email = "email@site.com",
                Firstname = "Firstname",
                Lastname = "Lastname",
                TeacherId = 1
            };

            user = new Logic.Security.User()
            {
                Email = dbResult.Email,
                Firstname = dbResult.Firstname,
                Lastname = dbResult.Lastname,
                Role = Logic.Security.Roles.Teacher
            };

            ctx
                .Setup(s => s.SP_Teacher_Login(It.IsAny<SP_Teacher_Login.Inputs>()))
                .Returns(new Models.Database.DBResult(200, "", dbResult));

            mapper
                .Setup(s => s.Map<Logic.Security.User>(It.IsAny<SP_Teacher_Login.Outputs>()))
                .Returns(user);
        }

        [Test]
        public void Login_WhenCall_ReturnDataShouldEqualToTheInputData()
        {
            var rst = teacher.Login(ctx.Object, mapper.Object, key, issuer);
            var data = rst.Data as Logic.Security.User;

            Assert.That(data.Email, Is.EqualTo(dbResult.Email));
            Assert.That(data.Firstname, Is.EqualTo(dbResult.Firstname));
            Assert.That(data.Lastname, Is.EqualTo(dbResult.Lastname));
        }

        [Test]
        public void Login_WhenCall_ShouldGenerateJWT()
        {
            var rst = teacher.Login(ctx.Object, mapper.Object, key, issuer);
            var data = rst.Data as Logic.Security.User;

            Assert.That(data.JWT, Is.Not.Empty);
            Assert.That(data.JWT.Length, Is.GreaterThan(10));
        }


        [Test]
        public void Login_WhenCall_ShouldMappDBResult()
        {
            teacher.Login(ctx.Object, mapper.Object, key, issuer);

            mapper.Verify(s => s.Map<Logic.Security.User>(dbResult));
        }

    }
}
