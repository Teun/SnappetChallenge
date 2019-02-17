using System;

namespace Dashboard.Dashboard
{
    public class DashboardPresenter
    {
        public void Present(Dashboard dashboard)
        {
            if (dashboard == null)
            {
                throw new ArgumentNullException(nameof(dashboard));
            }

            Console.WriteLine("Class activity report");
            Console.WriteLine();

            Console.WriteLine($"Start date:\t\t{dashboard.Start}");
            Console.WriteLine($"End date:\t\t{dashboard.End}");
            Console.WriteLine();

            Console.WriteLine($"Pupils present:\t\t{dashboard.PupilsPresent}");
        }
    }
}
