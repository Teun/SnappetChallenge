namespace TeacherApp.Models
{
    public interface ITeacherAppRepository
  {
    IQueryable<Work> Works { get; }
    IQueryable<Student> Students { get; }
  }
}
