using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Shouldly;
using Snappet.Entity;
using Snappet.Repository;
using Snappet.Repository.AutoComplete;
using Snappet.Service;

namespace Test.Unit
{
    public class SubmittedAnswerServiceTest
    {
        private SubmittedAnswerService _sut;
        private Mock<AutoCompleteRepositoryResolver> _autoCompleteRepositoryResolverMock;
        private Mock<IAutoCompleteRepository> _autoCompleteRepositoryMock;
        private Mock<ISubmittedAnswerRepository> _submittedAnswerRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _submittedAnswerRepositoryMock = new Mock<ISubmittedAnswerRepository>();
            _submittedAnswerRepositoryMock.Setup(repository => repository.GetAll()).Returns(() =>
                new[]
                {
                    new SubmittedAnswer
                    {
                        Correct = CorrectState.Incorrect
                    }
                }.AsQueryable());

            _autoCompleteRepositoryMock = new Mock<IAutoCompleteRepository>();
            _autoCompleteRepositoryMock.Setup(x => x.AutoComplete(It.IsAny<string>(), It.IsAny<int>())).Returns(
                Task.FromResult<ICollection<AutoCompleteItem>>(new[]
                {
                    new AutoCompleteItem
                    {
                        Identifier = "test1",
                        Type = AutoCompleteType.User
                    },
                    new AutoCompleteItem
                    {
                        Identifier = "test2",
                        Type = AutoCompleteType.User
                    }
                }));

            _autoCompleteRepositoryResolverMock = new Mock<AutoCompleteRepositoryResolver>();
            _autoCompleteRepositoryResolverMock.Setup(resolver => resolver.Invoke(It.IsAny<AutoCompleteType>()))
                .Returns(_autoCompleteRepositoryMock.Object);

            _sut = new SubmittedAnswerService(_autoCompleteRepositoryResolverMock.Object,
                _submittedAnswerRepositoryMock.Object);
        }

        [Test]
        public async Task Can_get_all()
        {
            var data = await _sut.GetAll(null);
            data.ShouldNotBeEmpty();
        }

        [Test]
        public async Task When_input_is_correct_auto_complete_returns_items()
        {
            var result = await _sut.AutoComplete("test input", 5, AutoCompleteType.User);
            result.ShouldNotBeEmpty();
        }

        [Test]
        public async Task When_input_length_is_smaller_than_2_then_auto_complete_returns_empty_enumerable()
        {
            var result = await _sut.AutoComplete("t", 5, AutoCompleteType.User);
            result.ShouldBeEmpty();
        }
    }
}