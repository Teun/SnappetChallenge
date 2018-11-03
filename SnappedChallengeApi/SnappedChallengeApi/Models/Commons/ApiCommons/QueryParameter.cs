using SnappedChallengeApi._Corelib.Extensions;
using SnappedChallengeApi.Models.Constants;
using System.Collections.Generic;
using System.Linq;

namespace SnappedChallengeApi.Models.Commons.ApiCommons
{
    public class QueryParameter
    {
        public int Limit { get; set; }

        public int Offset { get; set; }

        public int ExpandLevel { get; set; }

        public List<string> ExpandChildFilters = new List<string>();

        public string Fields = string.Empty;

        public bool First { get; set; }

        public bool Last { get; set; }

        public bool Count { get; set; }

        public bool WithCount { get; set; }

        public string Language { get; set; }

        public string Value { get; set; }

        public string AuthorityPath { get; set; }

        public string AbsolutePath { get; set; }

        public string MainPath { get; set; }

        public string HttpMethod { get; set; }

        public string QueryString { get; set; }


        public string SortExpression = string.Empty;

        public Dictionary<string, string> OtherQueryParameters = new Dictionary<string, string>();

        public List<string> ValidationErrors = new List<string>();

        public QueryParameter(int? defaultRecordCount = null)
        {
            Limit = defaultRecordCount.IsNotNullAndEmpty() && 
                    defaultRecordCount.Value > 0 ? defaultRecordCount.Value : ServiceConstants.DefaultRecordCount;
            Language = ServiceConstants.DefaultLanguageCode;
            ExpandLevel = 0;
        }

        public bool HasError()
        {
            if (ValidationErrors.IsNotNullAndEmpty() && ValidationErrors.Any())
            {
                return true;
            }

            return false;
        }
        public void AddExpandChildFilter(string expand)
        {
            ExpandChildFilters = ExpandChildFilters.IsNotNullAndEmpty() ? new List<string>() : ExpandChildFilters;
            if (!ExpandChildFilters.Contains(expand))
            {
                ExpandChildFilters.Add(expand);
            }
        }
        public void RemoveExpandChildFilter(string expand)
        {
            ExpandChildFilters = ExpandChildFilters.IsNotNullAndEmpty() ? new List<string>() : ExpandChildFilters;
            if (ExpandChildFilters.Contains(expand))
            {
                ExpandChildFilters.Remove(expand);
            }
        }
        public bool HasExpandChildFilter(string expand)
        {
            ExpandChildFilters = ExpandChildFilters.IsNotNullAndEmpty() ? new List<string>() : ExpandChildFilters;
            return ExpandChildFilters.Contains(expand);
        }
        public bool IsOtherParameterValueExists(string parameterName, string value)
        {
            if (OtherQueryParameters.IsNotNullAndEmpty() &&
                OtherQueryParameters.ContainsKey(parameterName) &&
                OtherQueryParameters[parameterName].IsNotNullAndEmpty() &&
                OtherQueryParameters[parameterName] == value)
            {
                return true;
            }

            return false;
        }

        public bool IsOtherParameterExists(string parameterName, bool checkIfHasValue)
        {
            if (OtherQueryParameters.IsNotNullAndEmpty() &&
                OtherQueryParameters.ContainsKey(parameterName))
            {
                if (checkIfHasValue && string.IsNullOrEmpty(OtherQueryParameters[parameterName]))
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public QueryParameter CloneWithRequiredParams()
        {
            return new QueryParameter()
            {
                OtherQueryParameters = this.OtherQueryParameters,
                Language = this.Language
            };
        }

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
