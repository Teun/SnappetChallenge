
using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.Dashboard;
using Dashboard.Domain;

using NUnit.Framework;

namespace Dashboard.Tests
{
    [TestFixture]
    public class DashboardBuilderTests
    {
        private DashboardBuilder _dashboardBuilder;

        [SetUp]
        public void SetUp()
        {
            _dashboardBuilder = new DashboardBuilder();
        }


        [Test]
        public void OutputsDates()
        {
            // arrange
            var answers = new List<Answer> {};
            var startDate = DateTimeOffset.Now.AddHours(-1);
            var endDate = DateTimeOffset.Now;

            // act
            var dashboard = _dashboardBuilder.Build(answers, startDate, endDate);

            // assert
            Assert.That(dashboard.Start, Is.EqualTo(startDate));
            Assert.That(dashboard.End, Is.EqualTo(endDate));
        }

        [Test]
        public void CalculatesNumberOfStudents()
        {
            // arrange
            var answers = new List<Answer>
            {
                BuildAnswer(userId: 1),
                BuildAnswer(userId: 2),
                BuildAnswer(userId: 1)
            };

            // act
            var dashboard = _dashboardBuilder.Build(answers, DateTimeOffset.Now.AddHours(-1), DateTimeOffset.Now);

            // assert
            Assert.That(dashboard.StudentsPresent, Is.EqualTo(2));
        }

        [Test]
        public void ReturnsTopicsHierarchy()
        {
            // arrange
            var answers = new List<Answer>
            {
                BuildAnswer(1, "Maths", "Arithmetic", "Add"),
                BuildAnswer(2, "Maths", "Arithmetic", "Add"),
                BuildAnswer(1, "Maths", "Arithmetic", "Multiply"),
                BuildAnswer(3, "Reading", "Letters", "Letter A"),
                BuildAnswer(2, "Reading", "Vocabulary", "Animals"),
            };

            // act
            var dashboard = _dashboardBuilder.Build(answers, DateTimeOffset.Now.AddHours(-1), DateTimeOffset.Now);

            // assert
            var topics = dashboard.Topics.ToList();

            Assert.That(topics.Count, Is.EqualTo(10));
            Assert.That(topics[0].TopicName, Is.EqualTo("Overall"));
            Assert.That(topics[1].TopicName, Is.EqualTo("Maths"));
            Assert.That(topics[2].TopicName, Is.EqualTo("Arithmetic"));
            Assert.That(topics[3].TopicName, Is.EqualTo("Add"));
            Assert.That(topics[4].TopicName, Is.EqualTo("Multiply"));
            Assert.That(topics[5].TopicName, Is.EqualTo("Reading"));
            Assert.That(topics[6].TopicName, Is.EqualTo("Letters"));
            Assert.That(topics[7].TopicName, Is.EqualTo("Letter A"));
            Assert.That(topics[8].TopicName, Is.EqualTo("Vocabulary"));
            Assert.That(topics[9].TopicName, Is.EqualTo("Animals"));
        }

        [Test]
        public void ReturnsTopicsNestingLevel()
        {
            // arrange
            var answers = new List<Answer>
            {
                BuildAnswer(1, "Maths", "Arithmetic", "Add"),
                BuildAnswer(1, "Maths", "Shapes", "Triangle"),
            };

            // act
            var dashboard = _dashboardBuilder.Build(answers, DateTimeOffset.Now.AddHours(-1), DateTimeOffset.Now);

            // assert
            var topics = dashboard.Topics.ToList();

            Assert.That(topics.Count, Is.EqualTo(6));
            Assert.That(topics[0].Level, Is.EqualTo(0));
            Assert.That(topics[1].Level, Is.EqualTo(1));
            Assert.That(topics[2].Level, Is.EqualTo(2));
            Assert.That(topics[3].Level, Is.EqualTo(3));
            Assert.That(topics[4].Level, Is.EqualTo(2));
            Assert.That(topics[5].Level, Is.EqualTo(3));
        }

        [Test]
        public void CalculatesExerciseCountPerTopic()
        {
            // arrange
            var answers = new List<Answer>
            {
                BuildAnswer(1, "Maths", "Arithmetic", "Add", 1),
                BuildAnswer(1, "Maths", "Arithmetic", "Add", 2),
                BuildAnswer(2, "Maths", "Arithmetic", "Add", 1),
                BuildAnswer(2, "Maths", "Arithmetic", "Add", 2),
                BuildAnswer(1, "Maths", "Arithmetic", "Multiply", 3),
                BuildAnswer(1, "Maths", "Shapes", "Triangle", 4),
                BuildAnswer(3, "Reading", "Letters", "Letter A", 5)
            };

            // act
            var dashboard = _dashboardBuilder.Build(answers, DateTimeOffset.Now.AddHours(-1), DateTimeOffset.Now);

            // assert
            var topics = dashboard.Topics.ToList();

            Assert.That(topics[0].ExerciseCount, Is.EqualTo(5)); // overall
            Assert.That(topics[1].ExerciseCount, Is.EqualTo(4)); // maths
            Assert.That(topics[2].ExerciseCount, Is.EqualTo(3)); // arithmetic
            Assert.That(topics[3].ExerciseCount, Is.EqualTo(2)); // add
            Assert.That(topics[4].ExerciseCount, Is.EqualTo(1)); // multiply
            Assert.That(topics[5].ExerciseCount, Is.EqualTo(1)); // shapes
            Assert.That(topics[6].ExerciseCount, Is.EqualTo(1)); // triangle
            Assert.That(topics[7].ExerciseCount, Is.EqualTo(1)); // reading
            Assert.That(topics[8].ExerciseCount, Is.EqualTo(1)); // letters
            Assert.That(topics[9].ExerciseCount, Is.EqualTo(1)); // letter A
        }

        [Test]
        public void CalculatesCorrectPercentagePerTopic()
        {
            // arrange
            var answers = new List<Answer>
            {
                BuildAnswer(1, "Maths", "Arithmetic", "Add", isCorrect: true),
                BuildAnswer(1, "Maths", "Arithmetic", "Add", isCorrect: false),
                BuildAnswer(2, "Maths", "Arithmetic", "Add", isCorrect: false),
                BuildAnswer(2, "Maths", "Arithmetic", "Add", isCorrect: true),
                BuildAnswer(1, "Maths", "Arithmetic", "Multiply", isCorrect: false),
                BuildAnswer(1, "Maths", "Shapes", "Triangle", isCorrect: false),
                BuildAnswer(3, "Reading", "Letters", "Letter A", isCorrect: true)
            };

            // act
            var dashboard = _dashboardBuilder.Build(answers, DateTimeOffset.Now.AddHours(-1), DateTimeOffset.Now);

            // assert
            var topics = dashboard.Topics.ToList();

            Assert.That(topics[0].CorrectAnswersRate, Is.EqualTo(0.43).Within(0.01));      // overall 4/7
            Assert.That(topics[1].CorrectAnswersRate, Is.EqualTo(0.33).Within(0.01));      // maths 2/6
            Assert.That(topics[2].CorrectAnswersRate, Is.EqualTo(0.40).Within(0.01));      // arithmetic 2/5
            Assert.That(topics[3].CorrectAnswersRate, Is.EqualTo(0.50).Within(0.01));      // add 2/4
            Assert.That(topics[4].CorrectAnswersRate, Is.EqualTo(0.00).Within(0.01));      // multiply 0/1
            Assert.That(topics[5].CorrectAnswersRate, Is.EqualTo(0.00).Within(0.01));      // shapes 0/1
            Assert.That(topics[6].CorrectAnswersRate, Is.EqualTo(0.00).Within(0.01));      // triangle 0/1
            Assert.That(topics[7].CorrectAnswersRate, Is.EqualTo(1.00).Within(0.01));      // reading 1/1
            Assert.That(topics[8].CorrectAnswersRate, Is.EqualTo(1.00).Within(0.01));      // letters 1/1
            Assert.That(topics[9].CorrectAnswersRate, Is.EqualTo(1.00).Within(0.01));      // letter A 1/1
        }

        [Test]
        public void CalculatesStudentsSharePerTopic()
        {
            // arrange
            var answers = new List<Answer>
            {
                BuildAnswer(1, "Maths", "Arithmetic", "Add"),
                BuildAnswer(1, "Maths", "Arithmetic", "Add"),
                BuildAnswer(2, "Maths", "Arithmetic", "Add"),
                BuildAnswer(2, "Maths", "Arithmetic", "Add"),
                BuildAnswer(1, "Maths", "Arithmetic", "Multiply"),
                BuildAnswer(1, "Maths", "Shapes", "Triangle"),
                BuildAnswer(3, "Reading", "Letters", "Letter A")
            };

            // act
            var dashboard = _dashboardBuilder.Build(answers, DateTimeOffset.Now.AddHours(-1), DateTimeOffset.Now);

            // assert
            var topics = dashboard.Topics.ToList();

            Assert.That(topics[0].StudentsShare, Is.EqualTo(1.00).Within(0.01));      // overall 3/3
            Assert.That(topics[1].StudentsShare, Is.EqualTo(0.66).Within(0.01));      // maths 2/3
            Assert.That(topics[2].StudentsShare, Is.EqualTo(0.66).Within(0.01));      // arithmetic 2/3
            Assert.That(topics[3].StudentsShare, Is.EqualTo(0.66).Within(0.01));      // add 2/3
            Assert.That(topics[4].StudentsShare, Is.EqualTo(0.33).Within(0.01));      // multiply 1/3
            Assert.That(topics[5].StudentsShare, Is.EqualTo(0.33).Within(0.01));      // shapes 1/3
            Assert.That(topics[6].StudentsShare, Is.EqualTo(0.33).Within(0.01));      // triangle 1/3
            Assert.That(topics[7].StudentsShare, Is.EqualTo(0.33).Within(0.01));      // reading 1/3
            Assert.That(topics[8].StudentsShare, Is.EqualTo(0.33).Within(0.01));      // letters 1/3
            Assert.That(topics[9].StudentsShare, Is.EqualTo(0.33).Within(0.01));      // letter A 1/3
        }


        [Test]
        public void ReturnsStudentsListInAlphabeticalOrder()
        {
            // arrange
            var answers = new List<Answer>
            {
                BuildAnswer(userId: 2),
                BuildAnswer(userId: 1),
                BuildAnswer(userId: 1)
            };

            // act
            var dashboard = _dashboardBuilder.Build(answers, DateTimeOffset.Now.AddHours(-1), DateTimeOffset.Now);

            // assert
            var students = dashboard.Students.ToList();
            Assert.That(students.Count, Is.EqualTo(2));
            Assert.That(students[0].Name, Is.EqualTo("Student 1"));
            Assert.That(students[1].Name, Is.EqualTo("Student 2"));
        }

        [Test]
        public void ReturnsFinishedExercisesPerStudent()
        {
            // arrange
            var answers = new List<Answer>
            {
                BuildAnswer(userId: 1, exerciseId: 1),
                BuildAnswer(userId: 1, exerciseId: 2),
                BuildAnswer(userId: 2, exerciseId: 1)
            };

            // act
            var dashboard = _dashboardBuilder.Build(answers, DateTimeOffset.Now.AddHours(-1), DateTimeOffset.Now);

            // assert
            var students = dashboard.Students.ToList();
            Assert.That(students.Count, Is.EqualTo(2));
            Assert.That(students[0].ExerciseCount, Is.EqualTo(2));
            Assert.That(students[1].ExerciseCount, Is.EqualTo(1));
        }

        [Test]
        public void ReturnsCorrectAnswersRatioPerStudent()
        {
            // arrange
            var answers = new List<Answer>
            {
                BuildAnswer(userId: 1, isCorrect: true),
                BuildAnswer(userId: 1, isCorrect: false),
                BuildAnswer(userId: 2, isCorrect: true)
            };

            // act
            var dashboard = _dashboardBuilder.Build(answers, DateTimeOffset.Now.AddHours(-1), DateTimeOffset.Now);

            // assert
            var students = dashboard.Students.ToList();
            Assert.That(students.Count, Is.EqualTo(2));
            Assert.That(students[0].CorrectAnswersRatio, Is.EqualTo(0.5f).Within(0.1));
            Assert.That(students[1].CorrectAnswersRatio, Is.EqualTo(1.0f).Within(0.1));
        }

        [Test]
        public void IgnoresAnswersOutsideOfDatePeriod()
        {
            DateTimeOffset past = DateTimeOffset.Now.AddDays(-10); 
            DateTimeOffset start = DateTimeOffset.Now.AddHours(-1);
            DateTimeOffset inBetween = DateTimeOffset.Now;
            DateTimeOffset end = DateTimeOffset.Now.AddHours(+1);
            DateTimeOffset future = DateTimeOffset.Now.AddDays(+10);

            // arrange
            var answers = new List<Answer>
            {
                BuildAnswer(1, "Maths", "Arithmetic", "Add", submitDate: inBetween),
                BuildAnswer(2, "Maths", "Arithmetic", "Add", submitDate: inBetween),
                BuildAnswer(3, "Maths", "Shapes", "Triangle", submitDate: past),
                BuildAnswer(4, "Reading", "Letters", "Letter A", submitDate: future)
            };

            // act
            var dashboard = _dashboardBuilder.Build(answers, start, end);

            // assert
            Assert.That(dashboard.Topics.Any(it => it.TopicName == "Reading"), Is.False);
            Assert.That(dashboard.Topics.Any(it => it.TopicName == "Shapes"), Is.False);
            Assert.That(dashboard.Students.Any(it => it.Name == "Student 3"), Is.False);
            Assert.That(dashboard.Students.Any(it => it.Name == "Student 4"), Is.False);
        }

        private Answer BuildAnswer(int userId,
            string subject = "subject",
            string domain = "domain",
            string objective = "objective",
            int exerciseId = 1,
            bool isCorrect = true,
            DateTimeOffset? submitDate = null)
        {
            return new Answer(
                1,
                submitDate ?? DateTimeOffset.Now,
                isCorrect,
                0,
                userId,
                exerciseId,
                0,
                subject,
                domain,
                objective
            );
        }
    }
}
