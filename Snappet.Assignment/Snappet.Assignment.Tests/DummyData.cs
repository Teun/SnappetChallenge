using Snappet.Assignment.Entities.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snappet.Assignment.Tests
{

    public class DummyData
    {


        private static ICollection<User> _users;
        private static ICollection<Exercise> _exercises;
        private static ICollection<Work> _works;


        public static IEnumerable<User> Users
        {

            get
            {
                if (_users == null)
                {
                    _users = new List<User>();
                    for (int i = 1; i < 10; i++)
                    {
                        _users.Add(new User()
                        {
                            Id = i,
                            Name = "user-" + i


                        });
                    }
                }

                return _users;
            }
        }
        public static IEnumerable<Exercise> Exercises
        {
            get
            {
                if (_exercises == null)
                {
                    _exercises = new List<Exercise>();
                    for (int i = 1; i < 10; i++)
                    {
                        _exercises.Add(new Exercise()
                        {
                            Id = i,
                            Name = "Exercise-" + i

                        });
                    }
                }

                return _exercises;
            }
        }
        public static IEnumerable<Work> Works
        {
            get
            {
                if (_works == null)
                {
                    _works = new List<Work>();
                    var today = new DateTime(2015, 03, 24, 09, 50, 00);
                    for (int i = 1; i < 200; i++)
                    {
                        var randamId = new Random().Next(1, 9);
                        var user = Users.FirstOrDefault(c => c.Id == randamId);
                        var exercise = Exercises.FirstOrDefault(c => c.Id == randamId);

                        _works.Add(new Work()
                        {
                            SubmittedAnswerId = i,

                            Correct = i % 2 == 0 ? true : false,

                            Difficulty = i / 3,

                            Domain = "Domain-" + i,

                            ExerciseId = exercise.Id,
                            Exercise = exercise,

                            LearningObjective = "Learning-Objectives-" + i,

                            Progress = Convert.ToInt16(i * 3),

                            Subject = "Subject-" + i,

                            SubmitDateTime = today.AddMinutes(i),

                            UserId = user.Id,
                            User = user

                        });


                    }
                }
                return _works;
            }

        }


    }
}
