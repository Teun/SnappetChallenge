using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SnappetChallenge.Core.Entities;
using SnappetChallenge.Core.Interfaces;

namespace SnappetChallenge.Core.Services
{
    public class AssessmentService : IAssessmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AssessmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.AutoDetectChange = false;
            _unitOfWork.ValidateOnSaveEnabled = false;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }


        public void InsertBulkAssessments(string assessments)
        {
            _unitOfWork.AssessmentCommands.ExecuteSqlCommand(assessments);
        }

        public void ClearData()
        {
            _unitOfWork.AssessmentCommands.ExecuteSqlCommand("TRUNCATE TABLE Assessment");
        }
        public IEnumerable<Assessment> Query(AssessmentFilterModel assessmentFilterModel)
        {

            try
            {
                List<Expression<Func<Assessment, bool>>> filters = new List<Expression<Func<Assessment, bool>>>();
                Func<IQueryable<Assessment>, IOrderedQueryable<Assessment>> orderBy = c => c.OrderBy(d => d.SubmitDateTime);

                AppendFilters(assessmentFilterModel, filters);

                orderBy = AppendOrders(assessmentFilterModel, orderBy);
                long itemsCount;
                var result = _unitOfWork.AssessmentQueries.GetPage(out itemsCount, assessmentFilterModel.PageSize, assessmentFilterModel.SkipRecords, filters, orderBy);

                assessmentFilterModel.TotalRecords = itemsCount;
                assessmentFilterModel.TotalPages = (assessmentFilterModel.TotalRecords - 1) / assessmentFilterModel.PageSize + 1;
                return result.AsEnumerable();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private Func<IQueryable<Assessment>, IOrderedQueryable<Assessment>> AppendOrders(AssessmentFilterModel assessmentFilterModel, Func<IQueryable<Assessment>, IOrderedQueryable<Assessment>> orderBy)
        {
            if (!string.IsNullOrEmpty(assessmentFilterModel.SortParameter))
            {
                if (assessmentFilterModel.SortParameter == nameof(assessmentFilterModel.UserId))
                {
                    if (assessmentFilterModel.SortDirection)
                        orderBy = c => c.OrderBy(d => d.UserId);
                    else
                        orderBy = c => c.OrderByDescending(d => d.UserId);
                }

                if (assessmentFilterModel.SortParameter == nameof(assessmentFilterModel.Correct))
                {
                    if (assessmentFilterModel.SortDirection)
                        orderBy = c => c.OrderBy(d => d.Correct);
                    else
                        orderBy = c => c.OrderByDescending(d => d.Correct);
                }

                if (assessmentFilterModel.SortParameter == nameof(assessmentFilterModel.Difficulty))
                {
                    if (assessmentFilterModel.SortDirection)
                        orderBy = c => c.OrderBy(d => d.Difficulty);
                    else
                        orderBy = c => c.OrderByDescending(d => d.Difficulty);
                }

                if (assessmentFilterModel.SortParameter == nameof(assessmentFilterModel.Domain))
                {
                    if (assessmentFilterModel.SortDirection)
                        orderBy = c => c.OrderBy(d => d.Domain);
                    else
                        orderBy = c => c.OrderByDescending(d => d.Domain);
                }

                if (assessmentFilterModel.SortParameter == nameof(assessmentFilterModel.ExerciseId))
                {
                    if (assessmentFilterModel.SortDirection)
                        orderBy = c => c.OrderBy(d => d.ExerciseId);
                    else
                        orderBy = c => c.OrderByDescending(d => d.ExerciseId);
                }

                if (assessmentFilterModel.SortParameter == nameof(assessmentFilterModel.LearningObjective))
                {
                    if (assessmentFilterModel.SortDirection)
                        orderBy = c => c.OrderBy(d => d.LearningObjective);
                    else
                        orderBy = c => c.OrderByDescending(d => d.LearningObjective);
                }

                if (assessmentFilterModel.SortParameter == nameof(assessmentFilterModel.Progress))
                {
                    if (assessmentFilterModel.SortDirection)
                        orderBy = c => c.OrderBy(d => d.Progress);
                    else
                        orderBy = c => c.OrderByDescending(d => d.Progress);
                }

                if (assessmentFilterModel.SortParameter == nameof(assessmentFilterModel.Subject))
                {
                    if (assessmentFilterModel.SortDirection)
                        orderBy = c => c.OrderBy(d => d.Subject);
                    else
                        orderBy = c => c.OrderByDescending(d => d.Subject);
                }

                if (assessmentFilterModel.SortParameter == nameof(assessmentFilterModel.SubmitDateTime))
                {
                    if (assessmentFilterModel.SortDirection)
                        orderBy = c => c.OrderBy(d => d.SubmitDateTime);
                    else
                        orderBy = c => c.OrderByDescending(d => d.SubmitDateTime);
                }

                if (assessmentFilterModel.SortParameter == nameof(assessmentFilterModel.SubmittedAnswerId))
                {
                    if (assessmentFilterModel.SortDirection)
                        orderBy = c => c.OrderBy(d => d.SubmittedAnswerId);
                    else
                        orderBy = c => c.OrderByDescending(d => d.SubmittedAnswerId);
                }
            }

            return orderBy;
        }

        private void AppendFilters(AssessmentFilterModel assessmentFilterModel, List<Expression<Func<Assessment, bool>>> filters)
        {
            if (!string.IsNullOrEmpty(assessmentFilterModel.SubmitDateTime ))
            {
                var isCorrectDateTime = DateTime.TryParse(assessmentFilterModel.SubmitDateTime, out DateTime submitDateTime);
                if (isCorrectDateTime)
                {
                    DateTime startSubmitDateTime = submitDateTime.AddMinutes(-3);
                    DateTime endSubmitDateTime = submitDateTime.AddMinutes(3);
                    filters.Add(c => c.SubmitDateTime >= startSubmitDateTime && c.SubmitDateTime<= endSubmitDateTime);
                }
            }
            if (!string.IsNullOrEmpty(assessmentFilterModel.Correct))
            {
                filters.Add(c => c.Correct.ToLower().Contains(assessmentFilterModel.Correct.ToLower()));
            }

            if (!string.IsNullOrEmpty(assessmentFilterModel.Progress))
            {
                filters.Add(c => c.Progress.ToLower().Contains(assessmentFilterModel.Progress.ToLower()));
            }

            if (assessmentFilterModel.SubmittedAnswerId != 0)
            {
                filters.Add(c => c.SubmittedAnswerId == assessmentFilterModel.SubmittedAnswerId);
            }

            if (assessmentFilterModel.UserId != 0)
            {
                filters.Add(c => c.UserId == assessmentFilterModel.UserId);
            }

            if (assessmentFilterModel.ExerciseId != 0)
            {
                filters.Add(c => c.ExerciseId == assessmentFilterModel.ExerciseId);
            }

            if (!string.IsNullOrEmpty(assessmentFilterModel.Difficulty))
            {
                filters.Add(c => c.Difficulty.ToLower().Contains(assessmentFilterModel.Difficulty.ToLower()));
            }

            if (!string.IsNullOrEmpty(assessmentFilterModel.Subject))
            {
                filters.Add(c => c.Subject.ToLower().Contains(assessmentFilterModel.Subject.ToLower()));
            }

            if (!string.IsNullOrEmpty(assessmentFilterModel.Domain))
            {
                filters.Add(c => c.Domain.ToLower().Contains(assessmentFilterModel.Domain.ToLower()));
            }

            if (!string.IsNullOrEmpty(assessmentFilterModel.LearningObjective))
            {
                filters.Add(c => c.LearningObjective.ToLower().Contains(assessmentFilterModel.LearningObjective.ToLower()));
            }
        }

        public long GetAssessmentsCount()
        {
            return _unitOfWork.AssessmentQueries.GetAllEntityCount();
        }


    }
}
