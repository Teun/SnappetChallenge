namespace StudyResultsAnalysis.Tests.Models.Repository
{
  using System;
  using System.IO;
  using System.Web;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Shared.Helpers;
  using StudyResultsAnalysis.Models.Repository;

  [TestClass]
  public class StudyDataRepositoryTests
  {
    [TestMethod]
    public void GetStudyData_All()
    {
      HttpContext.Current = new HttpContext(new HttpRequest("", "http://localhost:2920",""), new HttpResponse(new StringWriter()));
      IStudyDataRepository repository = new StudyDataRepository(new LocalPathProvider());
      var result = repository.GetStudyData();
      Assert.IsNotNull(result);
    }

    [TestMethod]
    public void GetStudyDataByDay_SimpleTest()
    {
      HttpContext.Current = new HttpContext(new HttpRequest("", "http://localhost:2920", ""), new HttpResponse(new StringWriter()));
      IStudyDataRepository repository = new StudyDataRepository(new LocalPathProvider());
      var result = repository.GetStudyDataByDay(DateTime.Parse("2015-03-23"));
      Assert.IsNotNull(result);
      Assert.AreNotEqual(result.Count, 0);
    }

    [TestMethod]
    public void GetStudyDataByStudentIdTest()
    {
      HttpContext.Current = new HttpContext(new HttpRequest("", "http://localhost:2920", ""), new HttpResponse(new StringWriter()));
      IStudyDataRepository repository = new StudyDataRepository(new LocalPathProvider());
      var result = repository.GetStudyDataByStudentId(40282);
      Assert.IsNotNull(result);
      Assert.AreNotEqual(result.Count, 0);
    }
  }
}