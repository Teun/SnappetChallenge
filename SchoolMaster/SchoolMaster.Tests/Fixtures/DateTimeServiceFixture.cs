using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolMaster.Services;

namespace SchoolMaster.Tests.Fixtures
{
    public class DateTimeServiceFixture
    {
        public IDateTimeService DateTimeService { get; private set; }
        public DateTime Now => DateTimeService.Now;
        public DateTime FromDate => Now.AddHours(-5);

        public DateTimeServiceFixture()
        {
            Setup();
        }

        public void Setup()
        {
            DateTimeService = new DateTimeService();
        }
    }
}
