namespace SnappetChallenge.Web
{
    using System;
    using System.Configuration;

    public static class AppSettings
    {
        public static DateTime DefaultDateTimeStart
        {
            get
            {
                return DateTime.Parse(ConfigurationManager.AppSettings["DefaultDateTimeStart"]);
            }
        }

        public static DateTime DefaultDateTimeEnd
        {
            get
            {
                return DateTime.Parse(ConfigurationManager.AppSettings["DefaultDateTimeEnd"]);
            }
        }

        public static int DefaultPageSize
        {
            get { return 50; }
        }
    }
}