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
    public class ScatterPlotControllerTest
    {
        private Mock<IStudentSkillRepository> _mockStudentRepository;
        private Mock<IScatterPlotDataFacade> _mockScatterPlotDataFacade;
        public ScatterPlotControllerTest()
        {

        }
        [TestInitialize]
        public void InitializeMocks()
        {
            _mockStudentRepository = new Mock<IStudentSkillRepository>();
            _mockScatterPlotDataFacade = new Mock<IScatterPlotDataFacade>();
        }
        [TestMethod]
        public void GenerateScatterPlotDataReturnsBadRequestErrorForInvalidDate()
        {
            //Arrange
            var controller = new ScatterPlotGeneratorController(_mockStudentRepository.Object,
                _mockScatterPlotDataFacade.Object);
            //Act
            var actionResult = controller.GenerateScatterPlotData("2017-14-23", "");

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void GenerateScatterPlotDataReturnsBadRequestForEmptyDate()
        {
            //Arrange
            var controller = new ScatterPlotGeneratorController(_mockStudentRepository.Object,
               _mockScatterPlotDataFacade.Object);

            //Act
            var actionResult = controller.GenerateScatterPlotData("", "");

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestResult));
        }

        [TestMethod]
        public void GenerateScatterPlotDataReturnsNotFoundForMismatchDate()
        {
            //Arrange
            _mockStudentRepository.Setup(p => p.FindByDate(It.IsAny<DateTime>())).Returns(new List<StudentSkill>());
            var controller = new ScatterPlotGeneratorController(_mockStudentRepository.Object,
               _mockScatterPlotDataFacade.Object);

            //Act
            var actionResult = controller.GenerateScatterPlotData("2017-06-01", "");

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            _mockStudentRepository.Verify(p => p.FindByDate(It.IsAny<DateTime>()), Times.AtLeastOnce);

        }

        [TestMethod]
        public void GenerateScatterPlotDataReturnsNotFoundForInvalidSamplings()
        {
            //Arrange
            var skills = MockedStudentSkills();
            _mockStudentRepository.Setup(p => p.FindByDate(It.IsAny<DateTime>())).Returns(skills);

            _mockScatterPlotDataFacade.Setup(p => p.GenerateScatterPlotData(It.IsAny<IEnumerable<StudentSkill>>(), ""))
                                        .Returns(new List<KeyValuePair<double, double>>());
     
            var controller = new ScatterPlotGeneratorController(_mockStudentRepository.Object,
                _mockScatterPlotDataFacade.Object);

            //Act
            var actionResult = controller.GenerateScatterPlotData("2017-03-01", "");

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
            _mockStudentRepository.Verify(p => p.FindByDate(It.IsAny<DateTime>()), Times.Once);
            _mockScatterPlotDataFacade.Verify(p => p.GenerateScatterPlotData(It.IsAny<IEnumerable<StudentSkill>>(), ""), Times.Once);
        }

        [TestMethod]
        public void GenerateScatterPlotDataReturnsValidSamplings()
        {
            //Arrange
            var mockedSkills = MockedStudentSkills();
            var mockedDataSample = MockedDataSample();
            _mockStudentRepository.Setup(p => p.FindByDate(It.IsAny<DateTime>())).Returns(mockedSkills);
            _mockScatterPlotDataFacade.Setup(p => p.GenerateScatterPlotData(mockedSkills, ""))
                                       .Returns(mockedDataSample);

        
            var controller = new ScatterPlotGeneratorController(_mockStudentRepository.Object,
                _mockScatterPlotDataFacade.Object);

            //Act
            var actionResult = controller.GenerateScatterPlotData("2017-03-01", "");

            //Assert
            var result = actionResult as OkNegotiatedContentResult<IEnumerable<KeyValuePair<double,double>>>;
            var datapoint = result.Content;
            Assert.IsInstanceOfType(actionResult, typeof(OkNegotiatedContentResult<IEnumerable<KeyValuePair<double, double>>>));
            _mockStudentRepository.Verify(p => p.FindByDate(It.IsAny<DateTime>()), Times.Once);
            _mockScatterPlotDataFacade.Verify(p => p.GenerateScatterPlotData(mockedSkills, ""), Times.Once);
        }
        private IEnumerable<StudentSkill> MockedStudentSkills()
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

        private IEnumerable<KeyValuePair<double,double>> MockedDataSample()
        {
            return new List<KeyValuePair<double, double>>
            {
                new KeyValuePair<double, double>(2,3),
                new KeyValuePair<double, double>(4,3)
            };
        }
    }
}
