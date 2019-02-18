using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.Dashboard.Models;
using Dashboard.Domain;

namespace Dashboard.Dashboard
{
    public class DashboardBuilder
    {
        public DashboardModel Build(IEnumerable<Answer> answers, DateTimeOffset from, DateTimeOffset to)
        {
            if (answers == null)
            {
                throw new ArgumentNullException(nameof(answers));
            }

            IReadOnlyCollection<Answer> periodAnswers = answers
                .Where(answer => answer.SubmitDateTime >= from && answer.SubmitDateTime <= to)
                .ToList();

            if (periodAnswers.Count == 0)
            {
                throw new InvalidOperationException($"No answers found in period {from} - {to}");
            }

            int totalExerciseCount = periodAnswers.GroupBy(it => it.ExerciseId).Count();

            var students = periodAnswers.GroupBy(answer => answer.UserId)
                .Select(group => GetStudentStats(group.Key, group.ToList(), totalExerciseCount))
                .OrderBy(student => student.Name)
                .ToList();

            var rootTopic = BuildTopicHierarchy(periodAnswers);

            var topics = GatherTopicStatsRecursive(rootTopic, DashboardModel.ROOT_TOPIC_LEVEL, students.Count).ToList();

            return new DashboardModel(from, to, topics, students);
        }

        private StudentModel GetStudentStats(int userId, IReadOnlyCollection<Answer> group, int totalExerciseCount)
        {
            // fake a nice student name, as we don't have it
            string name = "Student " + userId;

            int studentExerciseCount = group.GroupBy(it => it.ExerciseId).Count();
            float finishedExerciseShare = (float)studentExerciseCount / totalExerciseCount;

            int correctAnswersCount = group.Count(it => it.IsCorrect);
            int answersCount = group.Count();
            float correctnessRatio = (float)correctAnswersCount / answersCount;

            return new StudentModel(name, studentExerciseCount, correctnessRatio, finishedExerciseShare);
        }

        private IEnumerable<TopicModel> GatherTopicStatsRecursive(Topic topic, int level, int overallStudentsCount)
        {
            var topicStats = topic.GetStatistics();

            var topicModel = new TopicModel(
                topic.Name,
                level,
                topicStats.ExerciseCount,
                topicStats.CorrectAnswersRate,
                (float)topicStats.StudentsCount / overallStudentsCount
            );

            yield return topicModel;

            foreach (Topic subtopic in topic.Subtopics)
            {
                foreach (var subtopicDashboardModel in GatherTopicStatsRecursive(subtopic, level + 1, overallStudentsCount))
                {
                    yield return subtopicDashboardModel;
                }
            }
        }

        private Topic BuildTopicHierarchy(IReadOnlyCollection<Answer> answers)
        {
            return new Topic("", answers, GroupBySubject(answers));
        }

        private IReadOnlyCollection<Topic> GroupBySubject(IEnumerable<Answer> answers)
        {
            return answers.GroupBy(answer => answer.Subject)
                .Select(group => new Topic(group.Key, group.ToList(), GroupByDomain(group)))
                .ToList();
        }

        private IReadOnlyCollection<Topic> GroupByDomain(IEnumerable<Answer> answers)
        {
            return answers.GroupBy(answer => answer.Domain)
                .Select(group => new Topic(group.Key, group.ToList(), GroupByLearningObjective(group)))
                .ToList();
        }

        private IReadOnlyCollection<Topic> GroupByLearningObjective(IEnumerable<Answer> answers)
        {
            return answers.GroupBy(answer => answer.LearningObjective)
                .Select(group => new Topic(group.Key, group.ToList(), new List<Topic>(0)))
                .ToList();
        }
    }
}
