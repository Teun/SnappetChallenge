using SnappetChallengAPI.Model;
using SnappetChallengAPI.Repository;

namespace SnappetChallengAPI.Service
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        public StudentService(StudentRepository assessmentRepository)
        {
            _studentRepository = assessmentRepository;
        }
        public List<StatisticalReport> GetStatisticalReportService(DateTime from, DateTime to)
        {
            try
            {
                var assessments = _studentRepository.LoadStudents();
                var results = assessments.GroupBy(p => p.Subject, (key, value) => new {
                                                                                         sub = key,
                                                                                         newlist = value.ToList()
                                                                                         .Where(x => x.SubmitDateTime >= from & x.SubmitDateTime <= to)
                                                                                         });

                List<StatisticalReport> assessmentLst = new List<StatisticalReport>();

                foreach (var gitem in results)
                {
                    assessmentLst.Add(new StatisticalReport
                    {
                        Subject = gitem.sub,
                        PassCount = gitem.newlist.Where(a => a.Correct == 1).Count(),
                        FailCount = gitem.newlist.Where(a => a.Correct == 0).Count()
                    });

                }

                return assessmentLst;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
        public List<string> GetDomains()
        {
            try
            {
                List<string> result = new List<string>();
                var students = _studentRepository.LoadStudents();

                var domains = students.Select(x => x.Domain).Distinct().ToList();
                return domains;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<string> GetSubjects()
        {
            try
            {
                List<string> result = new List<string>();
                var students = _studentRepository.LoadStudents();

               var subjects = students.Select(x => x.Subject).Distinct().ToList();
                return subjects;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Student> GetFilteredStudents(FilterReport filter)
        {
            try
            {
                var students = _studentRepository.LoadStudents();

                var filterStudent = students.Where(s =>
                                                s.SubmitDateTime >= filter.StartDate
                                                && s.SubmitDateTime <= filter.EndDate);

                if (filter.Domain.Any())
                    filterStudent = filterStudent.Where(student => filter.Domain.Any(d => d == student.Domain));

                if (filter.Subject.Any())
                    filterStudent = filterStudent.Where(student => filter.Subject.Any(d => d == student.Subject));


                var filterValue = filterStudent.Skip(filter.SkipRows).Take(filter.TakeRows).ToList();
                return filterValue;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
