using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Snappet.Borisov.Test.Infrastructure;

namespace Snappet.Borisov.Test.Domain.Specs
{
    public class describe_SubmittedAnswerProvider : nspec
    {
        private void before_each()
        {
            ISubmittedAnswerConfiguration configuration = new FakeISubmittedAnswerConfiguration();
            IReadSubmittedAnswers readSumbittedAnswers = new SubmittedAnswerReader(configuration);
            IConvertSubmittedAnswers convertSubmittedAnswers = new SubmittedAnswerConverter();
            _target = new SubmittedAnswerProvider(readSumbittedAnswers, convertSubmittedAnswers);
        }

        private class FakeISubmittedAnswerConfiguration : ISubmittedAnswerConfiguration
        {
            public string Url => "https://raw.githubusercontent.com/Snappet/SnappetChallenge/master/Data/work.json";
        }

        private void when_read()
        {
            act = () => _result = _target.GetAll();
            it["returns expected number of answers"] = () => _result.Count().Should().Be(37812);
        }

        private SubmittedAnswerProvider _target;
        private IEnumerable<SubmittedAnswer> _result;
    }
}