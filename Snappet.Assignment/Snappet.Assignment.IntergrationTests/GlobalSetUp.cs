using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Snappet.Assignment.Data.Context;
using Snappet.Assignment.Entities.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Snappet.Assignment.IntergrationTests
{
    [SetUpFixture]
    public class GlobalSetUp
    {

        private SchoolDbContext _context;
        public static string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=SnappetAssignment_Tests;Trusted_Connection=True;MultipleActiveResultSets=true";
        private const string MigrationAssemply = "Snappet.Assignment.WebApp";
        private static ICollection<User> _users;
        private static ICollection<Exercise> _exercises;
        private static ICollection<Work> _works;


        private static IEnumerable<User> Users
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
        private static IEnumerable<Exercise> Exercises
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
                        _works.Add(new Work()
                        {
                            SubmittedAnswerId = i,

                            Correct = i % 2 == 0 ? true : false,

                            Difficulty = i / 3,

                            Domain = "Domain-" + i,

                            ExerciseId = _exercises.FirstOrDefault(c => c.Id == randamId).Id,

                            LearningObjective = "Learning-Objectives-" + i,

                            Progress = Convert.ToInt16(i * 3),

                            Subject = "Subject-" + i,

                            SubmitDateTime = today.AddMinutes(i),

                            UserId = _users.FirstOrDefault(c => c.Id == randamId).Id

                        });


                    }
                }
                return _works;
            }

        }
        public GlobalSetUp()
        {

        }

        [OneTimeSetUp]

        public void OneTimeSetUp()
        {
            var service = new ServiceCollection().AddEntityFrameworkSqlServer().BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<SchoolDbContext>();
            builder.UseSqlServer(ConnectionString, option => option.MigrationsAssembly(MigrationAssemply))
                .UseInternalServiceProvider(service);
            _context = new SchoolDbContext(builder.Options);

            _context.Database.Migrate();
            Seed();


        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _users = null;
            _exercises = null;
            _works = null;
            _context.Database.EnsureDeleted();
        }

        private void Seed()
        {

            _context.Exercises.AddRange(Exercises);
            _context.Users.AddRange(Users);
            _context.Works.AddRange(Works);


            _context.SaveChanges();
        }
    }
}