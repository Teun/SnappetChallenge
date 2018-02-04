namespace StudyResultsAnalysis.Models.Repository
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Web;
  using Newtonsoft.Json;
  using Shared.Definitions;
  using Shared.Helpers;

  public sealed class StudyDataRepository : IStudyDataRepository
  {
    private readonly PathProvider _pathProvider;

    public StudyDataRepository()
    {
    }

    public StudyDataRepository(PathProvider pathProvider)
    {
      _pathProvider = pathProvider;
    }

    /// <summary>
    /// Sets the data to the cache if it is empty.
    /// </summary>
    /// <returns></returns>
    internal void CheckCacheData()
    {
      try
      {
        if (HttpContext.Current.Cache[Constants.CacheDataName] != null)
          return;

        var path = _pathProvider?.GetPath() ?? new HostingPathProvider().GetPath();
        if (path != null)
          using (var streamReader = File.OpenText(path))
          {
            JsonSerializer serializer = new JsonSerializer();
            var studyData = (List<StudyDataEntity>) serializer.Deserialize(streamReader, typeof(List<StudyDataEntity>));
            HttpContext.Current.Cache[Constants.CacheDataName] = studyData;
          }
        else
        {
          Console.WriteLine("Reading work.json failed");
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
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

      CheckCacheData();

      return (List<StudyDataEntity>)HttpContext.Current.Cache[Constants.CacheDataName];
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
      return studyData.Where(data => Equals(data.SubmitDateTime.Date, date)).ToList();
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