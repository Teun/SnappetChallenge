using System.IO;
using FluentAssertions;
using Snappet.Borisov.Test.Infrastructure;

namespace Snappet.Borisov.Test.Domain.Specs
{
    public class describe_SubmittedAnswerReader : nspec
    {
        private void before_each()
        {
            ISubmittedAnswerConfiguration configuration = new FakeISubmittedAnswerConfiguration();
            _target = new SubmittedAnswerReader(configuration);
        }

        private void when_read()
        {
            act = () => _result = _target.Read();
            it["returns a stream"] = () => _result.Should().NotBeNull();
            after = () => { _result.Dispose(); };
        }

        private SubmittedAnswerReader _target;
        private Stream _result;
    }

    public class FakeISubmittedAnswerConfiguration : ISubmittedAnswerConfiguration
    {
        public string Url => "https://raw.githubusercontent.com/Snappet/SnappetChallenge/master/Data/work.json";
    }
}