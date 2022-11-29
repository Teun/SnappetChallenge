using TeacherApp.Data;

namespace TeacherApp.Models
{
    public class EFTeacherAppRepository : ITeacherAppRepository
  {
    private TeacherAppDbContext context;
    public EFTeacherAppRepository(TeacherAppDbContext ctx)
    {
      context = ctx;
    }
    public IQueryable<Work> Works => context.Works;
	public IQueryable<Student> Students => context.Students;
	}
}
