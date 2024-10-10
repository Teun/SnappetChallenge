using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ClassMonitor.Web.Pages
{
    public class IndexModel(ILogger<IndexModel> logger) : PageModel
    {
        private readonly ILogger<IndexModel> _logger = logger;

        private static readonly DateTime MaxDate = new(2015, 03, 24, 11, 30, 00, DateTimeKind.Utc);

        [BindProperty(SupportsGet = true)]
        public DateTime? DateTime { get; set; }

        [BindProperty(SupportsGet = true)]
        public Tabs? SelectedTab { get; set; }

        public void OnGet()
        {
            SelectedTab ??= Tabs.Daily;

            if (DateTime is null || DateTime > MaxDate)
            {
                DateTime = MaxDate;
            }
        }

        public enum Tabs
        {
            Daily,
            Monthly
        }
    }
}
