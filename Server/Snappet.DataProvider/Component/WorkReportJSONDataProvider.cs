using Snappet.Common.BusinessLogic;
using Snappet.DataProvider.DataProvider;
using Snappet.Model.DataProvider;
using Snappet.Model.Domain;
using Snappet.Model.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Snappet.DataProvider.Component
{
    public class WorkReportJSONDataProvider : BusinessComponent, IWorkReportJSONDataProvider
    {
        public WorkReportJSONDataProvider(IUnityContainer container) : base(container)
        {
        }
        protected IWorkDataProvider workDataProvider;
        internal IWorkDataProvider WorkDataProvider
        {
            get { return workDataProvider = workDataProvider ?? new DataProviderFactory().GetDataProvider(); }
        }

        public IEnumerable<FilterDateSubject> GetFilterDetails()
        {
            var works = GetAllWorks();
            List<FilterDateSubject> dateSubjectDomains = new List<FilterDateSubject>();
            if (works != null && works.Any())
            {
                var dates = works.GroupBy(p => p.SubmitDate);

                GetFilter(dates, dateSubjectDomains);
            }

            return dateSubjectDomains;
        }

        public IEnumerable<Work> GetAllWorks()
        {
            return WorkDataProvider.GetWorkDetails();
        }
        private static void GetFilter(IEnumerable<IGrouping<DateTime, Work>> dates, List<FilterDateSubject> dateSubjectDomains)
        {
            foreach (var date in dates)
            {
                var filterDateSubject = new FilterDateSubject();
                filterDateSubject.DateTime = date.Key;
                var subjects = date.GroupBy(p => p.Subject);
                filterDateSubject.SubjectsList = new List<FilterSubjectDomain>();
                foreach (var subject in subjects)
                {
                    var filterSubjectDomain = new FilterSubjectDomain();
                    filterSubjectDomain.Name = subject.Key;
                    filterSubjectDomain.DomainList = subject.GroupBy(p => p.Domain).Select(p => p.Key).ToList();
                    filterDateSubject.SubjectsList.Add(filterSubjectDomain);
                }
                dateSubjectDomains.Add(filterDateSubject);
            }
        }

        public IEnumerable<FilterDateSubject> GetFilterDetailsByDate(string dateTime)
        {
            var works = GetAllWorks();
            List<FilterDateSubject> dateSubjectDomains = new List<FilterDateSubject>();
            if (works != null && works.Any())
            {
                var dates = works.Where(p => p.SubmitDate == DateTime.Parse(dateTime)).GroupBy(p => p.SubmitDate);

                GetFilter(dates, dateSubjectDomains);
            }

            return dateSubjectDomains;
        }

    }
}
