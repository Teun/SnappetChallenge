using System.Linq;
using FlashMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnappetChallenge.Core;
using SnappetChallenge.Core.Builders;
using SnappetChallenge.Data;
using SnappetChallenge.Data.Models;

namespace SnappetChallenge.Tests
{
    [TestClass]
    public class ImagesProviderTests
    {
        private Mock<IImagesRepository> imageRepositorySetup;
        private IImageProvider imageProvider;

        [TestInitialize]
        public void Initialize()
        {
            var mockRepository = new MockRepository(MockBehavior.Loose);
            imageRepositorySetup = mockRepository.Create<IImagesRepository>();
            var imageBuilder = new ImageBuilder(new MappingConfiguration());
            imageBuilder.RegisterMapping();
            imageProvider = new ImageProvider(imageRepositorySetup.Object, imageBuilder);
        }

        [TestMethod]
        public void Should_ReturnImageFromRepository()
        {
            imageRepositorySetup.Setup(ir => ir.Query())
                .Returns(new[]
                {
                    new ImageDb
                    {
                        ImageUrl = "Test",
                        ImageId = 1
                    }
                }.AsQueryable());
            var image = imageProvider.FindImage(1);
            image.Should().NotBeNull();
            image.ImageId.Should().Be(1);
            image.ImageUrl.Should().Be("Test");
        }

        [TestMethod]
        public void Should_ReturnNullIfNotFound()
        {
            imageRepositorySetup.Setup(ir => ir.Query())
                .Returns(Enumerable.Empty<ImageDb>().AsQueryable());
            var image = imageProvider.FindImage(1);
            image.Should().BeNull();
        }
    }
}