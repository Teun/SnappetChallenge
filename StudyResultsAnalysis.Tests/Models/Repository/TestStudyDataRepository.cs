namespace StudyResultsAnalysis.Tests.Models.Repository
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;
  using StudyResultsAnalysis.Models;
  using StudyResultsAnalysis.Models.Repository;

  public sealed class TestStudyDataRepository : IStudyDataRepository
  {

    /// <summary>
    /// Sets the data to the cache if it is empty.
    /// </summary>
    /// <returns></returns>
    
    private List<StudyDataEntity> GetTestData()
    {
      var testProducts = new List<StudyDataEntity>
      {
        new StudyDataEntity
        {
          SubmittedAnswerId = 2395278,
          SubmitDateTime = DateTime.Parse("2015-03-02T07:35:38.740", null, DateTimeStyles.AdjustToUniversal),
          Correct = 1,
          Progress = 0,
          UserId = 40281,
          ExerciseId = 1038396,
          Difficulty = "-200",
          Subject = "Begrijpend Lezen",
          Domain = "-",
          LearningObjective = "Diverse leerdoelen Begrijpend Lezen"
        },
        new StudyDataEntity
        {
          SubmittedAnswerId = 2396494,
          SubmitDateTime = DateTime.Parse("2015-03-02T07:36:48.530", null, DateTimeStyles.AdjustToUniversal),
          Correct = 1,
          Progress = 2,
          UserId = 40281,
          ExerciseId = 1029120,
          Difficulty = "329.2341931",
          Subject = "Begrijpend Lezen",
          Domain = "-",
          LearningObjective = "Diverse leerdoelen Begrijpend Lezen"
        },
        new StudyDataEntity
        {
          SubmittedAnswerId = 2396638,
          SubmitDateTime = DateTime.Parse("2015-03-02T07:36:55.487", null, DateTimeStyles.AdjustToUniversal),
          Correct = 1,
          Progress = 0,
          UserId = 40282,
          ExerciseId = 1013670,
          Difficulty = "-200",
          Subject = "Begrijpend Lezen",
          Domain = "-",
          LearningObjective = "Diverse leerdoelen Begrijpend Lezen"
        },
        new StudyDataEntity
        {
          SubmittedAnswerId = 65346620,
          SubmitDateTime = DateTime.Parse("2015-03-23T13:19:14.937", null, DateTimeStyles.AdjustToUniversal),
          Correct = 1,
          Progress = 0,
          UserId = 40275,
          ExerciseId = 392520,
          Difficulty = "216.6723998",
          Subject = "Spelling",
          Domain = "Taalverzorging",
          LearningObjective = "woorden eindigend op -d of -t"
        }
      };

      return testProducts;
    }

    /// <summary>
    /// Get all the data at once.
    /// </summary>
    /// <returns>StudyDataDto in List form</returns>
    public List<StudyDataEntity> GetStudyData()
    {
      return GetFullData();
    }

    /// <summary>
    /// Check if data is cached and return the full data to be used
    /// </summary>
    /// <returns></returns>
    internal List<StudyDataEntity> GetFullData()
    {
      //Since we are relying on the cache, it needs to be filled in for the first request.
      //a better solution would be to preload it upon service start

      return GetTestData();
    }

    /// <summary>
    /// Get the data of the particular date.
    /// Answers the minimum "waar heeft mijn klas vandaag aan gewerkt" question
    /// </summary>
    /// <param name="date"></param>
    /// <returns>StudyDataDto in List for the date</returns>
    public List<StudyDataEntity> GetStudyDataByDay(DateTime date)
    {
      var studyData = GetFullData();

      return studyData.Where(data => data.SubmitDateTime.Date == date).ToList();
    }

    /// <summary>
    /// Get the data over a specific student.
    /// </summary>
    /// <param name="studentId"></param>
    /// <returns></returns>
    public List<StudyDataEntity> GetStudyDataByStudentId(int studentId)
    {
      var studyData = GetFullData();

      return studyData.Where(data => data.UserId == studentId).ToList();
    }
  }
}