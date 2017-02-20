using System;
using NServiceBus.Logging;
using Snappet.Test.Kernel;
using Snappet.Test.TopStudents.Interface.Dtos;

namespace Snappet.Test.TopStudents.Core.Model
{
    public class TopStudentsRecord : Entity
    {
        private static readonly ILog Log = LogManager.GetLogger<TopStudentsRecord>();
        
        private TopStudentsRecord()
        {
              
        }

        public static TopStudentsRecord Create(string subject, TopStudentsRecordTypes type, DateTime date)
        {
            return new TopStudentsRecord
            {
                Subject = subject,
                Type = type,
                RecordDate = AdjustDate(type, date)
            };
        }

        public int? Top1StudentId { get; private set; }
        public decimal? Top1Difficulty { get; private set; }
        public int? Top2StudentId { get; private set; }
        public decimal? Top2Difficulty { get; private set; }
        public int? Top3StudentId { get; private set; }
        public decimal? Top3Difficulty { get; private set; }

        public byte[] RowVersion { get; set; }
        public DateTime RecordDate { get; private set; }
        public string Subject { get; private set; }
        public TopStudentsRecordTypes Type { get; private set; }

        public bool SetInRanking(int studentId, decimal difficulty)
        {
            bool rankingChanged = false;
            if (!Top1Difficulty.HasValue || difficulty > Top1Difficulty)
            {
                Log.Info($"Student {studentId} reached Top 1 of {Type} with {difficulty}");
                SetTop1(studentId, difficulty);
                rankingChanged = true;
            }
            else if (studentId != Top1StudentId)
            {
                if (!Top2Difficulty.HasValue || difficulty > Top2Difficulty)
                {
                    Log.Info($"Student {studentId} reached Top 2 of {Type} with {difficulty}");
                    SetTop2(studentId, difficulty);
                    rankingChanged = true;
                }
                else if (studentId != Top2StudentId)
                {
                    if (!Top3Difficulty.HasValue || difficulty > Top3Difficulty)
                    {
                        Log.Info($"Student {studentId} reached Top 3 of {Type} with {difficulty}");
                        SetTop3(studentId, difficulty);
                        rankingChanged = true;
                    }
                }
            }
            return rankingChanged;
        }

        private void SetTop1(int studentId, decimal difficulty)
        {
            if (Top2StudentId != studentId)
            {
                PushSecondDown();
            }
            PushFirstDown();
            Top1Difficulty = difficulty;
            Top1StudentId = studentId;
        }

        private void SetTop2(int studentId, decimal difficulty)
        {
            if(studentId == Top1StudentId)
                throw new InvalidOperationException("Cannot demote a student");

            PushSecondDown();
            Top2Difficulty = difficulty;
            Top2StudentId = studentId;
        }

        private void SetTop3(int studentId, decimal difficulty)
        {
            if (studentId == Top1StudentId || studentId == Top2StudentId)
                throw new InvalidOperationException("Cannot demote a student");

            Top3Difficulty = difficulty;
            Top3StudentId = studentId;
        }

        private void PushFirstDown()
        {
            Top2Difficulty = Top1Difficulty;
            Top2StudentId = Top1StudentId;
        }
        private void PushSecondDown()
        {
            Top3Difficulty = Top2Difficulty;
            Top3StudentId = Top2StudentId;
        }
        
        public static string GetKey(string subject, TopStudentsRecordTypes type, DateTime recordDate)
        {
            return $"{subject}-{type}-{AdjustDate(type, recordDate)}";
        }

        public static DateTime AdjustDate(TopStudentsRecordTypes type, DateTime recordDate)
        {
            DateTime date;
            switch (type)
            {
                case TopStudentsRecordTypes.Day:
                    date = recordDate.Date;
                    break;
                case TopStudentsRecordTypes.Month:
                    date = new DateTime(recordDate.Year, recordDate.Month, 1);
                    break;
                case TopStudentsRecordTypes.Course:
                    int year;
                    if (recordDate.Month <= 8)
                    {
                        year = recordDate.Year - 1;
                    }
                    else
                    {
                        year = recordDate.Year;
                    }
                    date = new DateTime(year, 9, 1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return date;
        }
    }
}