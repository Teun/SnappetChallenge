using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnappedChallengeApi.Models.Constants
{
    /// <summary>
    /// All required constants must be defined in this class to controll all embededed values of the project
    /// Otherwise there can be embedded resources that everybody forget...
    /// </summary>
    public class ServiceConstants
    {
        public const string SettingTemplate = "ServiceSettings:{0}";
        /// <summary>
        /// DEfault api return content type constants
        /// </summary>
        public const string ApplicationJsonContent = "application/json";

        /// <summary>
        /// Default language code of execution of api (constant)
        /// </summary>
        public const string DefaultLanguageCode = "en-US";

        /// <summary>
        /// Default record count if get api request does not have limit query parameter for record fetch page size (constant)
        /// </summary>
        public const int DefaultRecordCount = 25;
    }
}
