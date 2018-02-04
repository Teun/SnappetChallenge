using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyResultsAnalysis.Controllers
{
  using Models;
  using Models.Repository;

  public class StudyResultsController : Controller
  {
    //TODO : implement and use Unity for DI to get rid of below dependency
    private readonly IStudyDataRepository _repository = new StudyDataRepository();

    public StudyResultsController()
    {
    }

    public StudyResultsController(IStudyDataRepository repository)
    {
      _repository = repository;
    }

    // GET: StudyResults
    public ActionResult Index()
    {
      //Setting up the default date for the valid first date
      StudyDataEntity model = new StudyDataEntity() { SubmitDateTime = DateTime.Parse("02/03/2015") };
      return View(model);
    }

    public ActionResult GetByDate(DateTime submitDateTime)
    {
      var result = _repository.GetStudyDataByDay(submitDateTime);
      ViewBag.PageTitle = $"Results for date: {submitDateTime}";
      return View(result);
    }

    public ActionResult GetAll()
    {
     var result = _repository.GetStudyData();
      return View(result);
    }

    public ActionResult GetByUserId(int userId)
    {
      var result = _repository.GetStudyDataByStudentId(userId);
      ViewBag.PageTitle = $"Results for Student Id: {userId}";
      return View(result); ;
    }
  }
}