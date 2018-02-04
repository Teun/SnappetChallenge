namespace StudyResultsAnalysis.Tests.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Security.Principal;
  using System.Web;
  using System.Web.Mvc;
  using System.Web.Routing;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using Models.Repository;
  using StudyResultsAnalysis.Controllers;
  using StudyResultsAnalysis.Models;
  using StudyResultsAnalysis.Models.Repository;

  [TestClass()]
  public class StudyDataControllerTests
  {


    [TestMethod()]
    public void GetAll_ShouldReturnAllData()
    {
      var controller = GetStudyResultsController(new TestStudyDataRepository());
      var result = controller.GetAll();
      Assert.IsInstanceOfType(result, typeof(ViewResult));
      var viewResult = result as ViewResult;
      if (viewResult != null)
      {
        var resultModel = (List<StudyDataEntity>) viewResult.Model;
        Assert.IsNotNull(resultModel);
        Assert.AreEqual(resultModel.Count, 4);
        Assert.AreEqual(resultModel[0].SubmittedAnswerId, 2395278);
      }
    }

    [TestMethod()]
    public void GetByDate_ShouldReturnOneRecord()
    {
      var controller = GetStudyResultsController(new TestStudyDataRepository());
      var result = controller.GetByDate(DateTime.Parse("2015-03-23"));
      Assert.IsInstanceOfType(result, typeof(ViewResult));
      var viewResult = result as ViewResult;
      if (viewResult != null)
      {
        var resultModel = (List<StudyDataEntity>)viewResult.Model;
        Assert.IsNotNull(resultModel);
        Assert.AreEqual(resultModel.Count, 1);
        Assert.AreEqual(resultModel[0].SubmittedAnswerId, 65346620);
      }
    }

    public void GetByDate_ShouldReturnThreeRecords()
    {
      var controller = GetStudyResultsController(new TestStudyDataRepository());
      var result = controller.GetByDate(DateTime.Parse("2015-03-02"));
      Assert.IsInstanceOfType(result, typeof(ViewResult));
      var viewResult = result as ViewResult;
      if (viewResult != null)
      {
        var resultModel = (List<StudyDataEntity>)viewResult.Model;
        Assert.IsNotNull(resultModel);
        Assert.AreEqual(resultModel.Count, 3);
        Assert.AreEqual(resultModel[0].SubmittedAnswerId, 2395278);
      }
    }

    [TestMethod()]
    public void GetByStudentId_TwoRecords()
    {
      var controller = GetStudyResultsController(new TestStudyDataRepository());
      var result = controller.GetByUserId(40281);
      Assert.IsInstanceOfType(result, typeof(ViewResult));
      var viewResult = result as ViewResult;
      if (viewResult != null)
      {
        var resultModel = (List<StudyDataEntity>)viewResult.Model;
        Assert.IsNotNull(resultModel);
        Assert.AreEqual(resultModel.Count, 2);
        Assert.AreEqual(resultModel[0].SubmittedAnswerId, 2395278);
        Assert.AreEqual(resultModel[1].SubmittedAnswerId, 2396494);
      }
    }


    private static StudyResultsController GetStudyResultsController(IStudyDataRepository repository)
    {
      var controller = new StudyResultsController(repository);
      controller.ControllerContext = new ControllerContext()
      {
        Controller = controller,
        RequestContext = new RequestContext(new MockHttpContext(), new RouteData())
      };

      return controller;
    }

    private class MockHttpContext : HttpContextBase
    {
      private readonly IPrincipal _user = new GenericPrincipal(
        new GenericIdentity("someUser"), null /* roles */);

      public override IPrincipal User
      {
        get
        {
          return _user;
        }
        set
        {
          base.User = value;
        }
      }
    }
  }
}