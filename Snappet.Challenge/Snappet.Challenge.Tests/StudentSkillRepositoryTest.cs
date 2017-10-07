using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Snappet.Data;
using Snappet.Model;
using Snappet.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snappet.Challenge.Tests
{
    [TestClass]
    public class StudentSkillRepositoryTest
    {
        Mock<IDataFactory> _mockDataFactory;
        public StudentSkillRepositoryTest()
        {

        }
        [TestInitialize]
        public void Intialize()
        {
            _mockDataFactory = new Mock<IDataFactory>();
        }

        [TestMethod]
        public void FindByDateReturnsZeroSkillsForUnMatchedDate()
        {
            //Arrange
            _mockDataFactory.Setup(p => p.FetchData()).Returns(new List<StudentSkill>());

            //Act
            var studentRepository = new StudentSkillRepository(_mockDataFactory.Object);
            var skills = studentRepository.FindByDate(new DateTime());

            //Assert
            Assert.IsTrue(skills.Count() == 0);


        }
        [TestMethod]
        public void FindByDateReturnsMoreThanOneSkillsForMatchedDate()
        {
            //Arrange
            var mockedSkills = MockSkills();
            _mockDataFactory.Setup(p => p.FetchData()).Returns(mockedSkills);

            //Act
            var studentRepository = new StudentSkillRepository(_mockDataFactory.Object);
            var skills = studentRepository.FindByDate(new DateTime());

            //Assert
            Assert.IsTrue(skills.Count() > 1);
        }

        private IList<StudentSkill> MockSkills()
        {
            var skills = new List<StudentSkill>
            {
                new StudentSkill
                {
                    Correct=true,
                    Domain="Test"
                },
                new StudentSkill
                {
                    Correct=true,
                    Domain="Test"
                }
            };
            return skills;
        }

    }
}
