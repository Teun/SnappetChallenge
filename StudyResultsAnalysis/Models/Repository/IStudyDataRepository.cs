namespace StudyResultsAnalysis.Models.Repository
{
  using System;
  using System.Collections.Generic;
  using Models;

  public interface IStudyDataRepository
  {
    /// <summary>
    /// Get all the data at once
    /// </summary>
    /// <returns>StudyDataDto in List form</returns>
    List<StudyDataEntity> GetStudyData();

    /// <summary>
    /// Get the data of the particular date
    /// </summary>
    /// <param name="date"></param>
    /// <returns>StudyDataDto in List for the date</returns>
    List<StudyDataEntity> GetStudyDataByDay(DateTime date);

    List<StudyDataEntity> GetStudyDataByStudentId(int studentId);
  }
}