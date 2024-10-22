namespace SnappetChallenge.Classroom.Domain.Errors;

public static class ClassroomErrors
{
    public static Error NotFound(int classroomId) => new(
        "Classroom.NotFound", $"The classroom with Id = '{classroomId}' was not found");
}
