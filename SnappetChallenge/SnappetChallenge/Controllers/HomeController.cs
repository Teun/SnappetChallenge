using Newtonsoft.Json;
using SnappetChallenge.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SnappetChallenge.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private const string AllExercisesSessionKey = "AllExercises";
        private const string DropDownsSessionKey = "AllDropdowns";

        /// <summary>
        /// Returns all exercises
        /// </summary>
        private IEnumerable<Exercise> GetExercises()
        {
            List<Exercise> exercises = new List<Exercise>();
            if (Session[AllExercisesSessionKey] != null)
            {
                exercises = (List<Exercise>)Session[AllExercisesSessionKey];
            }
            else
            {
                try
                {
                    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "App_Data\\work.json");
                    using (StreamReader reader = System.IO.File.OpenText(path))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        exercises = (List<Exercise>)serializer.Deserialize(reader, typeof(List<Exercise>));
                    }
                    Session[AllExercisesSessionKey] = exercises;
                }
                catch (FileNotFoundException ex)
                {
                    // Log exception
                }
                catch (Exception ex)
                {
                    // Log exception
                }
            }
            return exercises.AsEnumerable();
        }

        /// <summary>
        /// Return all exercises for a page
        /// </summary>
        [HttpGet]
        [OutputCache(Duration = 36000, VaryByParam = "pageNumber;exercisesPerPage")]
        public JsonResult Exercises(int pageNumber, int exercisesPerPage)
        {
            return Json(Paginate(GetExercises(), pageNumber, exercisesPerPage), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Returns all exercises for a page, on a given date
        /// </summary>
        [HttpGet]
        [OutputCache(Duration = 36000, VaryByParam = "date;pageNumber;exercisesPerPage")]
        public JsonResult SubmittedDate(DateTime date, int pageNumber, int exercisesPerPage)
        {
            var result = ExercisesByDate(date);
            return Json(Paginate(result, pageNumber, exercisesPerPage), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<Exercise> ExercisesByDate(DateTime date)
        {
            DateTime startDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            DateTime endDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
            var result = GetExercises().Where(exercise => exercise.SubmitDateTime >= startDate && exercise.SubmitDateTime <= endDate);
            return result;
        }

        /// <summary>
        /// Return all exercises for a page, in a given domain
        /// </summary>
        [HttpGet]
        [OutputCache(Duration = 36000, VaryByParam = "domain;pageNumber;exercisesPerPage")]
        public JsonResult Domain(String domain, int pageNumber, int exercisesPerPage)
        {
            var result = GetExercises().Where(exercise => !string.IsNullOrEmpty(exercise.Domain) && exercise.Domain.ToLower() == domain.ToLower());
            var jsonResult= Json(Paginate(result, pageNumber, exercisesPerPage), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        /// <summary>
        /// Return all exercises for a page, with a given subject
        /// </summary>
        [HttpGet]
        [OutputCache(Duration = 36000, VaryByParam = "subject;pageNumber;exercisesPerPage")]
        public JsonResult Subject(String subject, int pageNumber, int exercisesPerPage)
        {
            var result = GetExercises().Where(exercise => !string.IsNullOrEmpty(exercise.Subject) && exercise.Subject.ToLower() == subject.ToLower());
            return Json(Paginate(result, pageNumber, exercisesPerPage), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Return all exercises for a page, which have a progress that is greater than or equal
        /// to the given progress
        /// </summary>
        [HttpGet]
        [OutputCache(Duration = 36000, VaryByParam = "progress;pageNumber;exercisesPerPage")]
        public JsonResult Progress(int progress, int pageNumber, int exercisesPerPage)
        {
            var result= GetExercises().Where(exercise => exercise.Progress >= progress);
            return Json(Paginate(result, pageNumber, exercisesPerPage), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Return all exercises for a page, with a given exercise ID
        /// </summary>
        [HttpGet]
        [OutputCache(Duration = 36000, VaryByParam = "exerciseId;pageNumber;exercisesPerPage")]
        public JsonResult ExerciseId(int exerciseId, int pageNumber, int exercisesPerPage)
        {
            var result= GetExercises().Where(exercise => exercise.ExerciseId == exerciseId);
            return Json(Paginate(result, pageNumber, exercisesPerPage), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Return all exercises for a page, for a given user ID
        /// </summary>
        [HttpGet]
        [OutputCache(Duration = 36000, VaryByParam = "userId;pageNumber;exercisesPerPage")]
        public JsonResult UserId(int userId,int pageNumber, int exercisesPerPage)
        {
            var result = GetExercises().Where(exercise => exercise.UserId == userId);
            return Json(Paginate(result, pageNumber, exercisesPerPage), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Return all exercises for a page, with a given Learning Objective
        /// </summary>
        [HttpGet]
        [OutputCache(Duration = 36000, VaryByParam ="learningObjective;pageNumber;exercisesPerPage")]
        public JsonResult LearningObjective(string learningObjective, int pageNumber, int exercisesPerPage)
        {
            var result = GetExercises().Where(exercise => !string.IsNullOrWhiteSpace(exercise.LearningObjective) && 
                                                exercise.LearningObjective.ToLower().Replace(" ", "") == learningObjective.ToLower().Replace(" ", ""));
            return Json(Paginate(result, pageNumber, exercisesPerPage), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Returns a unique list of the exercise values
        /// </summary>
        [HttpGet]
        [OutputCache(Duration =36000)]
        public JsonResult DropdownValues()
        {
            return Json(GenerateDropDowns(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Returns only the exercises for the specified page
        /// </summary>
        private IEnumerable<Exercise> Paginate(IEnumerable<Exercise> exercises, int pageNumber, int exercisesPerPage)
        {
            int skip = (pageNumber - 1) * exercisesPerPage;
            return exercises.Skip(skip).Take(exercisesPerPage);
        }
        [HttpGet]
        [OutputCache(Duration = 36000, VaryByParam = "domain;exerciseID;learningObjective;selectedSubject;selectedUser;pageNumber;exercisesPerPage")]
        public JsonResult FilterExercises(string domain, int? exerciseID, string learningObjective, string selectedSubject, int? selectedUser, int pageNumber, int exercisesPerPage)
        {
            var result = GetExercises()
                .Where(exercise => domain != "undefined" && !string.IsNullOrEmpty(domain) ? exercise.Domain.ToLower() == domain.ToLower() : true)
                .Where(exercise => exerciseID != null && exerciseID > 0 ? exercise.ExerciseId == exerciseID : true)
                .Where(exercise => learningObjective != "undefined" && !string.IsNullOrEmpty(learningObjective) ? exercise.LearningObjective.ToLower().Replace(" ","")
                    .Contains(learningObjective.ToLower().Replace(" ", "")) : true)
                .Where(exercise => selectedSubject != "undefined" && !string.IsNullOrEmpty(selectedSubject) ? exercise.Subject.ToLower() == selectedSubject.ToLower() : true)
                .Where(exercise => selectedUser != null && selectedUser > 0 ? exercise.UserId == selectedUser : true);

            return Json(Paginate(result, pageNumber, exercisesPerPage), JsonRequestBehavior.AllowGet);
        }
        
        [OutputCache(Duration =36000)]
        [HttpGet]
        public JsonResult GetSummary(DateTime date)
        {
            var dropdowns = new Dropdowns();
            var allExercises = new List<Exercise>();
            var tasks = new List<Task<int>>();
            int correct = 0;

            Task dropdownTask = Task.Run(() =>
               {
                   dropdowns = GenerateDropDowns();
               });

            Task allexerciseTask = Task.Run(() =>
              {
                  allExercises = ExercisesByDate(date).ToList();
              });

            dropdownTask.Wait();
            allexerciseTask.Wait();
            var result = new ExerciseSummary();

            Task domainTask = Task.Run(() =>
              {

                  List<KeyValuePair<string, int>> domains = new List<KeyValuePair<string, int>>();
                  if (dropdowns.Domains.Any())
                  {
                      dropdowns.Domains.ToList().ForEach(domain =>
                      {
                          domains.Add(new KeyValuePair<string, int>(domain, allExercises.Count(ae => ae.Domain.ToLower() == domain.ToLower())));
                      });
                  }

                  result.Domains = domains;
              });

            Task learningObjectiveTask = Task.Run(() =>
              {
                  List<KeyValuePair<string, int>> learningObjectives = new List<KeyValuePair<string, int>>();
                  if (dropdowns.LearningObjectives.Any())
                  {
                      dropdowns.LearningObjectives.ToList().ForEach(learningObjective =>
                      {
                          learningObjectives.Add(new KeyValuePair<string, int>(learningObjective, allExercises.Count(ae => ae.LearningObjective.ToLower().Replace(" ", "").Contains(learningObjective.ToLower().Replace(" ", "")))));
                      });
                  }
                  result.LearningObjectives = learningObjectives;
              });

            Task subjectsTask = Task.Run(() =>
            {
                List<KeyValuePair<string, int>> subjects = new List<KeyValuePair<string, int>>();
                if (dropdowns.Subjects.Any())
                {
                    dropdowns.Subjects.ToList().ForEach(subject =>
                    {
                        subjects.Add(new KeyValuePair<string, int>(subject, allExercises.Count(ae => ae.Subject.ToLower() == subject.ToLower())));
                    });
                }
                result.Subjects = subjects;
            });

            Task correctTask = Task.Run(() =>
            {
                correct = allExercises.AsParallel().Count(exercise => exercise.Correct > 0);
            });

            Task submittedTimeTask = Task.Run(() =>
            {
                List<KeyValuePair<string, int>> submittedTimes = new List<KeyValuePair<string, int>>();
                allExercises.ForEach(exercise =>
                {
                    var hour = exercise.SubmitDateTime.Hour;
                    var minute = exercise.SubmitDateTime.Minute;
                    string minuteString = minute < 10 ? $"0{minute}" : $"{minute}";
                    string time = $"{hour}:{minuteString}";
                    if (!submittedTimes.Any(t => t.Key == time))
                    {
                        submittedTimes.Add(new KeyValuePair<string, int>(time, 1));
                    }
                    else
                    {
                        var value = submittedTimes.Where(t => t.Key == time).FirstOrDefault().Value;
                        submittedTimes.Remove(new KeyValuePair<string, int>(time, value));
                        submittedTimes.Add(new KeyValuePair<string, int>(time, value + 1));
                    }
                });
                result.SubmittedDateRanges = submittedTimes;
            });

            domainTask.Wait();
            learningObjectiveTask.Wait();
            subjectsTask.Wait();
            correctTask.Wait();
            submittedTimeTask.Wait();
            result.ExerciseCount = allExercises.Count();
            result.CorrectCount = correct;
            result.StudentCount = allExercises.Select(exercise => exercise.UserId).Distinct().Count();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public Dropdowns GenerateDropDowns()
        {
            var result = new Dropdowns();
            if (Session[DropDownsSessionKey] != null)
            {
                result = (Dropdowns)Session[DropDownsSessionKey];
            }
            else
            {
                var exercises = GetExercises();
                var domains = exercises.Select(exercise => exercise.Domain).Distinct().OrderBy(x => x);
                var exerciseIds = exercises.Select(exercise => exercise.ExerciseId).Distinct().OrderBy(x => x);
                var learningObjectives = exercises.Select(exercise => exercise.LearningObjective).Distinct().OrderBy(x => x);
                var subjects = exercises.Select(exercise => exercise.Subject).Distinct().OrderBy(x => x);
                var users = exercises.Select(exercise => exercise.UserId).Distinct().OrderBy(x => x);

                result = new Dropdowns
                {
                    Domains = domains,
                    ExerciseIds = exerciseIds,
                    LearningObjectives = learningObjectives,
                    Subjects = subjects,
                    Users = users
                };
            }
            return result;
        }
    }
}