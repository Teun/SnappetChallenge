using System.Web.Mvc;
using Snappet.Challenge.Web.Mvc.Data;

namespace Snappet.Challenge.Web.Mvc.Controllers
{
    public class BaseController : Controller
    {
        private static DataContext _snappetDataContext;

        /// <summary>
        /// Gets or sets the snappet <see cref="DataContext"/> object
        /// </summary>
        public DataContext SnappetDataContext {
            get { return _snappetDataContext; }
            
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseController() {
            if (_snappetDataContext == null)
            {
                _snappetDataContext = new DataContext();
            }
        }
    }
}