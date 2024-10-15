using Microsoft.AspNetCore.Mvc;
using SnappetChallenge.Classroom.Infrastructure.Repositories;

namespace SnappetChallenge.Classroom.Api.Controllers;

[Route("api/[controller]")]
public class ClassroomController(ILogger<ClassroomController> logger, IReadonlyClassroomRepository repository)
    : ControllerBase
{
    [HttpGet]
    [HttpGet("{classroomId:int}")]
    public async Task<IActionResult> Get(int classroomId, CancellationToken cancellationToken)
    {
        var classroom = await repository.GetClassroomOverviewAsync(classroomId, DateTime.UtcNow, cancellationToken);
        return Ok(classroom);
    }
    
    
    [HttpGet("{classroomId:int}/{currendDate:datetime}")]
    public async Task<IActionResult> Get(int classroomId, DateTime currendDate, CancellationToken cancellationToken)
    {
        var classroom = await repository.GetClassroomOverviewAsync(classroomId, currendDate, cancellationToken);
        return Ok(classroom);
    }
}