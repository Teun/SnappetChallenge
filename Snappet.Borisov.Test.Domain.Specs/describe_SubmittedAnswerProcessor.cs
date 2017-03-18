using System.Linq;
using FluentAssertions;
using Snappet.Borisov.Test.Domain.Processing;
using Snappet.Borisov.Test.Infrastructure;

namespace Snappet.Borisov.Test.Domain.Specs
{
    public class describe_SubmittedAnswerProcessor : nspec
    {
        private void before_each()
        {
            var dateTime = new DateTimeProvider();
            var configuration = new FakeISubmittedAnswerConfiguration();
            var reader = new SubmittedAnswerReader(configuration);
            var converter = new SubmittedAnswerConverter();
            var provider = new SubmittedAnswerProvider(reader, converter);
            var names = new StudentNameGenerator();
            _students = new Students(names);
            _target = new SubmittedAnswerProcessor(provider, _students, dateTime);
        }

        private void when_read()
        {
            act = () => _target.Process();
            it["returns expected number of students"] = () => _students.GetAll().Count().Should().Be(20);
        }

        private SubmittedAnswerProcessor _target;
        private Students _students;
    }
}