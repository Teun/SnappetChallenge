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

            var rootTopic = BuildTopicHierarchy(periodAnswers);

            var students = periodAnswers.GroupBy(answer => answer.UserId)
                .Select(group =>
                {
                    // fake a nice student name, as we don't have it
                    string name = "Student " + group.Key;

                    int exerciseCount = group.GroupBy(it => it.ExerciseId).Count();

                    int correctAnswersCount = group.Count(it => it.IsCorrect);
                    int answersCount = group.Count();
                    float correctnessRatio = (float) correctAnswersCount / answersCount;

                    return new StudentModel(name, exerciseCount, correctnessRatio);
                })
                .OrderBy(student => student.Name)
                .ToList();

            var topics = GatherTopicStats(rootTopic, 0, students.Count).ToList();

            return new DashboardModel(from, to, topics, students);
        }

        private IEnumerable<TopicDashboardModel> GatherTopicStats(Topic topic, int level, int overallStudentsCount)
        {
            var topicStats = topic.GetStatistics();

            var topicModel = new TopicDashboardModel(
                topic.Name,
                level,
                topicStats.ExerciseCount,
                topicStats.CorrectAnswersRate,
                (float)topicStats.StudentsCount / overallStudentsCount
            );


            yield return topicModel;

            foreach (Topic subtopic in topic.Subtopics)
            {
                foreach (var subtopicDashboardModel in GatherTopicStats(subtopic, level + 1, overallStudentsCount))
                {
                    yield return subtopicDashboardModel;
                }
            }
        }

        private Topic BuildTopicHierarchy(IReadOnlyCollection<Answer> answers)
        {
            // NOTE: root level should be localized here or in the presenter, hardcode for simplicity
            return new Topic("Overall", answers, GroupBySubject(answers));
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
