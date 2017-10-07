using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Snappet.Challenge.Controllers;
using Snappet.Challenge.Facade;
using Snappet.Challenge.Models;
using Snappet.Model;
using Snappet.Repository;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace Snappet.Challenge.Tests
{
    [TestClass]
    public class BelcurveGeneratorControllerTest
    {
        private Mock<IStudentSkillRepository> _mockStudentRepository;
        private Mock<IStatisticsDataFacade> _mockStatisticsDataFacade;
        public BelcurveGeneratorControllerTest()
        {

        }
        [TestInitialize]
        public void InitializeMocks()
        {
            _mockStudentRepository = new Mock<IStudentSkillRepository>();
            _mockStatisticsDataFacade = new Mock<IStatisticsDataFacade>();
       }
        [TestMethod]
        public void GenerateBellCurveDataReturnsBadRequestErrorForInvalidDate()
        {
            //Arrange
            var controller = new BellcurveGeneratorController(_mockStudentRepository.Object,
                _mockStatisticsDataFacade.Object);
            //Act
            var actionResult = controller.GenerateBellCurveData("2017-14-23", "");

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void GenerateBellCurveDataReturnsBadRequestForEmptyDate()
        {
            //Arrange
            var controller = new BellcurveGeneratorController(_mockStudentRepository.Object,
                _mockStatisticsDataFacade.Object);

            //Act
            var actionResult = controller.GenerateBellCurveData("", "");

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GenerateBellCurveDataReturnsNotFoundForMismatchDate()
        {
            //Arrange
            _mockStudentRepository.Setup(p => p.FindByDate(It.IsAny<DateTime>())).Returns(new List<StudentSkill>());
            var controller = new BellcurveGeneratorController(_mockStudentRepository.Object,
                _mockStatisticsDataFacade.Object);

            //Act
            var actionResult = controller.GenerateBellCurveData("2017-06-01", "");

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            _mockStudentRepository.Verify(p => p.FindByDate(It.IsAny<DateTime>()), Times.AtLeastOnce);

        }

        [TestMethod]
        public void GenerateBellCurveDataResturnsNotFoundForInvalidSamplings()
        {
            //Arrange
            var skills = MockedStudentSkills();
            _mockStudentRepository.Setup(p => p.FindByDate(It.IsAny<DateTime>())).Returns(skills);
            _mockStatisticsDataFacade
                .Setup(p => p.GenerateBellCurveData(It.IsAny<IList<StudentSkill>>(), ""))
                .Returns(new DataPoint());

            var controller = new BellcurveGeneratorController(_mockStudentRepository.Object,
                _mockStatisticsDataFacade.Object);

            //Act
            var actionResult = controller.GenerateBellCurveData("2017-03-01", "");

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            _mockStudentRepository.Verify(p => p.FindByDate(It.IsAny<DateTime>()), Times.Once);
            _mockStatisticsDataFacade.Verify(p => p.GenerateBellCurveData(It.IsAny<IList<StudentSkill>>(), ""), Times.Once);
        }

        [TestMethod]
        public void GenerateBellCurveDataReturnsValidSamplings()
        {
            //Arrange
            var mockedSkills = MockedStudentSkills();
            var mockedDataPoint = MockedDataPoints();
            _mockStudentRepository.Setup(p => p.FindByDate(It.IsAny<DateTime>())).Returns(mockedSkills);
            _mockStatisticsDataFacade
                .Setup(p => p.GenerateBellCurveData(mockedSkills, ""))
                .Returns(mockedDataPoint);

            var controller = new BellcurveGeneratorController(_mockStudentRepository.Object,
                _mockStatisticsDataFacade.Object);

            //Act
            var actionResult = controller.GenerateBellCurveData("2017-03-01", "");

            //Assert
            var result = actionResult as OkNegotiatedContentResult<DataPoint>;
            var datapoint = result.Content;
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<DataPoint>));
            _mockStudentRepository.Verify(p => p.FindByDate(It.IsAny<DateTime>()), Times.Once);
            _mockStatisticsDataFacade.Verify(p => p.GenerateBellCurveData(mockedSkills, ""), Times.Once);
        }
        private IList<StudentSkill> MockedStudentSkills()
        {
            var students = new List<StudentSkill>
            {
                new StudentSkill
                {
                    SubmitDateTime=new DateTime(2017,12,01),
                    UserId=2000,
                    Difficulty="209.09",
                    Correct=false
                }
            };
            return students;
        }

        private DataPoint MockedDataPoints()
        {
            var datapoint = new DataPoint
            {
                Data = new List<double> { 20.0, 40.0, 40.0 },
                Distribution = new List<double> { 34.0, 34.0, 12.0 }
            };
            return datapoint;
        }

    }
}
