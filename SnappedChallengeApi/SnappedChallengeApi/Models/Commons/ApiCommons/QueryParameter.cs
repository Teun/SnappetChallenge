using SnappedChallengeApi._Corelib.Extensions;
using SnappedChallengeApi.Models.Constants;
using System.Collections.Generic;
using System.Linq;

namespace SnappedChallengeApi.Models.Commons.ApiCommons
{
    /// <summary>
    /// Query parameter main model class for http request query parameters
    /// Not all of them required for this exercise
    /// </summary>
    public class QueryParameter
    {
        /// <summary>
        /// Page record size
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// page record start index
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// if more than one level required for the data expand this is the level 
        /// </summary>
        public int ExpandLevel { get; set; }

        /// <summary>
        /// Sometimes only some of the properties needed to be expand specially
        /// </summary>
        public List<string> ExpandChildFilters = new List<string>();

        /// <summary>
        /// Sometimes only required fields are needed for the response
        /// </summary>
        public string Fields = string.Empty;

        /// <summary>
        /// First record
        /// </summary>
        public bool First { get; set; }

        /// <summary>
        /// Last record
        /// </summary>
        public bool Last { get; set; }

        /// <summary>
        /// Return record count only
        /// </summary>
        public bool Count { get; set; }

        /// <summary>
        /// Return record count with result
        /// </summary>
        public bool WithCount { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Sort Expression
        /// </summary>
        public string SortExpression = string.Empty;

        /// <summary>
        /// Other not reserved word query parameters
        /// </summary>
        public Dictionary<string, string> OtherQueryParameters = new Dictionary<string, string>();

        /// <summary>
        /// Validation errors
        /// </summary>
        public List<string> ValidationErrors = new List<string>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="defaultRecordCount"></param>
        public QueryParameter(int? defaultRecordCount = null)
        {
            Limit = defaultRecordCount.IsNotNullAndEmpty() && 
                    defaultRecordCount.Value > 0 ? defaultRecordCount.Value : ServiceConstants.DefaultRecordCount;
            Language = ServiceConstants.DefaultLanguageCode;
            ExpandLevel = 0;
        }

        /// <summary>
        /// Has parse error or not check method
        /// </summary>
        /// <returns></returns>
        public bool HasError()
        {
            if (ValidationErrors.IsNotNullAndEmpty() && ValidationErrors.Any())
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryStringPropName"></param>
        /// <returns></returns>
        public string GetOtherParametersValue(string queryStringPropName)
        {
            string propValue = null;
            try
            {
                if (OtherQueryParameters.IsNotNullAndEmpty() && OtherQueryParameters.ContainsKey(queryStringPropName))
                {
                    var seekedRecord = OtherQueryParameters[queryStringPropName];
                    if (seekedRecord.IsNotNullAndEmpty())
                    {
                        propValue = seekedRecord;
                    }
                }
            }
            catch
            {
                //ignored
            }
            return propValue;
        }
    }
}
