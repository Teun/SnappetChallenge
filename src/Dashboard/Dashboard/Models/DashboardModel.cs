
using System;
using System.Collections.Generic;

namespace Dashboard.Dashboard.Models
{
    public class DashboardModel
    {
        public DateTimeOffset Start { get; }

        public DateTimeOffset End { get; }

        public int StudentsPresent => Students.Count;

        public IReadOnlyCollection<TopicModel> Topics { get; }

        public IReadOnlyCollection<StudentModel> Students { get; }

        public DashboardModel(
            DateTimeOffset start,
            DateTimeOffset end,
            IReadOnlyCollection<TopicModel> topics,
            IReadOnlyCollection<StudentModel> students
        )
        {
            Start = start;
            End = end;
            Topics = topics ?? throw new ArgumentNullException(nameof(topics));
            Students = students ?? throw new ArgumentNullException(nameof(students));
        }
    }
}
