using Xunit;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using SnappetChallenge.Classroom.Api.Controllers;
using SnappetChallenge.Classroom.Infrastructure.Repositories;

namespace SnappetChallenge.Classroom.Tests;

public class ClassroomControllerTests
{
    private readonly Fixture _fixture;
    private readonly IReadonlyClassroomRepository _repository;
    private readonly ClassroomController _controller;

    public ClassroomControllerTests()
    {
        _fixture = new Fixture();
        _repository = Substitute.For<IReadonlyClassroomRepository>();
        _controller = new ClassroomController(Substitute.For<ILogger<ClassroomController>>(), _repository)
        {
            ControllerContext = Substitute.For<ControllerContext>()
        };
        _controller.ControllerContext.HttpContext = Substitute.For<HttpContext>();
        
    }

    [Fact]
    public async Task GetClassroomOverview()
    {
        var classroomId = _fixture.Create<int>();

        var viewModel = _fixture.Build<Infrastructure.Repositories.ViewModels.ClassroomResponse>()
            .Create();
        
        _repository.GetClassroomOverviewAsync(classroomId, Arg.Any<DateTime>(), CancellationToken.None)
            .Returns(viewModel);

        var response = await _controller.Get(classroomId, CancellationToken.None);
        
        response.Should().BeOfType<OkObjectResult>()
            .Subject.Value.Should().BeOfType<Infrastructure.Repositories.ViewModels.ClassroomResponse>();

        await _repository
            .Received(1)
            .GetClassroomOverviewAsync(classroomId, Arg.Any<DateTime>(), Arg.Any<CancellationToken>());
    }
    
    [Fact]
    public async Task GetClassroomOverviewWithDate()
    {
        var classroomId = _fixture.Create<int>();
        var currentDate = _fixture.Create<DateTime>();

        var viewModel = _fixture.Build<Infrastructure.Repositories.ViewModels.ClassroomResponse>()
            .Create();
        
        _repository.GetClassroomOverviewAsync(classroomId, Arg.Any<DateTime>(), CancellationToken.None)
            .Returns(viewModel);

        var response = await _controller.Get(classroomId, currentDate, CancellationToken.None);
        
        response.Should().BeOfType<OkObjectResult>()
            .Subject.Value.Should().BeOfType<Infrastructure.Repositories.ViewModels.ClassroomResponse>();

        await _repository
            .Received(1)
            .GetClassroomOverviewAsync(classroomId, Arg.Any<DateTime>(), Arg.Any<CancellationToken>());
    }
    
}