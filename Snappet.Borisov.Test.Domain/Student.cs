using System;
using System.Collections.Generic;
using System.Linq;

namespace Snappet.Borisov.Test.Domain
{
    public class Student
    {
        private readonly Dictionary<Date, StudentDay> _days;
        private readonly int _userId;

        public Student(int userId, string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId));
            _days = new Dictionary<Date, StudentDay>();
            _userId = userId;
            Name = name;
        }

        public string Name { get; }

        public IEnumerable<StudentDay> Days => _days.Values;

        public void SubmitAnswer(SubmittedAnswer answer)
        {
            if (answer == null) throw new ArgumentNullException(nameof(answer));
            if (answer.UserId != _userId)
                throw new ArgumentException(
                    $"Can't submit an aswer for user with id {_userId}. Invalid user id {answer.UserId}",
                    nameof(answer));
            var key = new Date(answer.SubmitDateTime);
            var day = FindDay(key);
            if (day == null)
            {
                day = new StudentDay(_userId, key);
                _days.Add(key, day);
            }
            day.SubmitAnswer(answer);
        }

        /// <summary>
        ///     Assume the last day in the dictionary is today.
        ///     This is a valid assumption for this simple prototype.
        /// </summary>
        public IEnumerable<SubmittedAnswer> Today()
        {
            return _days.Last().Value.Answers;
        }

        private StudentDay FindDay(Date key)
        {
            StudentDay student;
            return _days.TryGetValue(key, out student) ? student : null;
        }

        public override string ToString()
        {
            return $"Student {_userId} Days {_days.Values.Count}";
        }
    }
}