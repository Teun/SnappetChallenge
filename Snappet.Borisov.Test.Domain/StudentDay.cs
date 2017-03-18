using System;
using System.Collections.Generic;

namespace Snappet.Borisov.Test.Domain
{
    public class StudentDay
    {
        private readonly List<SubmittedAnswer> _answers;
        private readonly Date _date;
        private readonly int _userId;

        public StudentDay(int userId, Date date)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId));
            if (date == null) throw new ArgumentNullException(nameof(date));
            _userId = userId;
            _date = date;
            _answers = new List<SubmittedAnswer>();
        }

        public IEnumerable<SubmittedAnswer> Answers => _answers;

        public void SubmitAnswer(SubmittedAnswer answer)
        {
            if (answer == null) throw new ArgumentNullException(nameof(answer));
            if (answer.UserId != _userId)
            {
                throw new ArgumentException(
                    $"Can't submit an aswer for user with id {_userId}. Invalid user id {answer.UserId}", 
                    nameof(answer));
            }
            if (new Date(answer.SubmitDateTime) != _date)
            {
                throw new ArgumentException(
                    $"Can't submit an aswer for a date {_date.Value:d}. Invalid date {answer.SubmitDateTime:d}", 
                    nameof(answer));
            }
            _answers.Add(answer);
        }

        public override string ToString()
        {
            return $"Student {_userId} Day {_date.Value:d} Answers {_answers.Count}";
        }
    }
}