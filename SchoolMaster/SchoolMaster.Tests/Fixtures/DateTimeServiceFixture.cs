using System;
using SchoolMaster.Services;

namespace SchoolMaster.Tests.Fixtures
{
    public class DateTimeServiceFixture
    {
        public DateTimeServiceFixture()
        {
            Setup();
        }

        public IDateTimeService DateTimeService { get; private set; }
        public DateTime Now => DateTimeService.Now;
        public DateTime FromDate => Now.AddHours(-5);

        public void Setup()
        {
            DateTimeService = new DateTimeService();
        }
    }
}