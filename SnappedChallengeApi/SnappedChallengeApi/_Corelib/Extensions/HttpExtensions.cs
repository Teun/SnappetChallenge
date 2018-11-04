using Microsoft.AspNetCore.Http;
using SnappedChallengeApi.Models.Commons.ApiCommons;
using SnappedChallengeApi.Models.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnappedChallengeApi._Corelib.Extensions
{
    public static class HttpExtensions
    {
        public static string JsonContent = "application/json; charset=UTF-8";

        public static string GetRequestUrl(this string serviceUrl, string route)
        {
            return $"{serviceUrl}{route}";
        }

        public static QueryParameter ParseQueryString(this HttpContext context, int? defaultRecordCount = null)
        {
            try
            {
                Dictionary<string, string> queryStringPairs = new Dictionary<string, string>();
                foreach (var key in context.Request.Query.Keys)
                {
                    queryStringPairs.Add(key.ToLower(), context.Request.Query[key].ToString().Trim());
                }

                QueryParameter parameters = new QueryParameter(defaultRecordCount);

                if (queryStringPairs != null && queryStringPairs.Any())
                {
                    foreach (var pairItem in queryStringPairs)
                    {
                        switch (pairItem.Key)
                        {
                            case "limit":
                                ParseLimitParameter(ref parameters, pairItem);
                                break;
                            case "first":
                                ParseFirstParameter(ref parameters, pairItem);
                                break;
                            case "last":
                                ParseLastParameter(ref parameters, pairItem);
                                break;
                            case "offset":
                                ParseOffsetParameter(ref parameters, pairItem);
                                break;
                            case "sort":
                                ParseSortParameter(ref parameters, pairItem);
                                break;
                            case "lang":
                                ParseLangParameter(ref parameters, pairItem);
                                break;
                            case "count":
                                ParseCountParameter(ref parameters, pairItem);
                                break;
                            case "withcount":
                                ParseWithCountParameter(ref parameters, pairItem);
                                break;
                            case "value":
                                parameters.Value = pairItem.Value;
                                break;
                            default:
                                ParseOtherQueryParameter(ref parameters, pairItem);
                                break;
                        }
                    }
                }

                return parameters;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region Other internal helpers
        private static void ParseOtherQueryParameter(ref QueryParameter parameters, KeyValuePair<string, string> pairItem)
        {
            try
            {
                if (pairItem.Key.IsNotNullAndEmpty())
                {
                    if (!parameters.OtherQueryParameters.ContainsKey(pairItem.Key))
                    {
                        parameters.OtherQueryParameters.Add(pairItem.Key, pairItem.Value);
                    }
                    else
                    {
                        var itemKeyCount = parameters.OtherQueryParameters.AsEnumerable().Count(f => f.Key == pairItem.Key);
                        parameters.OtherQueryParameters.Add(string.Format("{0}{1}", pairItem.Key, itemKeyCount), pairItem.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                //TODO log
            }
        }

        private static void ParseWithCountParameter(ref QueryParameter parameters, KeyValuePair<string, string> pairItem)
        {
            bool withCountBool = false;
            if (bool.TryParse(pairItem.Value, out withCountBool))
            {
                parameters.WithCount = withCountBool;
            }
            else
            {
                AddValidationError(ref parameters, "withCount parameter has invalid value (true/false expected)");
            }
        }

        private static void ParseCountParameter(ref QueryParameter parameters, KeyValuePair<string, string> pairItem)
        {
            bool countBool = false;
            if (bool.TryParse(pairItem.Value, out countBool))
            {
                parameters.Count = countBool;
            }
            else
            {
                AddValidationError(ref parameters, "count parameter has invalid value (true/false expected)");
            }
        }

        private static void ParseLangParameter(ref QueryParameter parameters, KeyValuePair<string, string> pairItem)
        {
            parameters.Language = pairItem.Value;

            if (parameters.Language.IsNotNullAndEmpty())
            {
                parameters.Language = ServiceConstants.DefaultLanguageCode;
            }
        }

        private static void ParseLimitParameter(ref QueryParameter parameters, KeyValuePair<string, string> pairItem)
        {
            int limitValue = 0;
            if (int.TryParse(pairItem.Value, out limitValue))
            {
                parameters.Limit = limitValue;
            }
            else
            {
                AddValidationError(ref parameters, "limit parameter must be an integer");
            }
        }

        private static void ParseFirstParameter(ref QueryParameter parameters, KeyValuePair<string, string> pairItem)
        {
            bool firstBool = false;
            if (bool.TryParse(pairItem.Value, out firstBool))
            {
                parameters.First = firstBool;
            }
            else
            {
                AddValidationError(ref parameters, "first parameter has invalid value (true/false expected)");
            }
        }

        private static void ParseLastParameter(ref QueryParameter parameters, KeyValuePair<string, string> pairItem)
        {
            bool lastBool = false;
            if (bool.TryParse(pairItem.Value, out lastBool))
            {
                parameters.Last = lastBool;
            }
            else
            {
                AddValidationError(ref parameters, "last parameter has invalid value (true/false expected)");
            }
        }

        private static void ParseOffsetParameter(ref QueryParameter parameters, KeyValuePair<string, string> pairItem)
        {
            int offsetValue = 0;
            if (int.TryParse(pairItem.Value, out offsetValue))
            {
                parameters.Offset = offsetValue;
            }
            else
            {
                AddValidationError(ref parameters, "offset parameter value must be integer");
            }
        }

        private static void ParseSortParameter(ref QueryParameter parameters, KeyValuePair<string, string> pairItem)
        {
            if (!string.IsNullOrEmpty(pairItem.Value))
            {
                parameters.SortExpression = pairItem.Value;
            }
        }

        private static void AddValidationError(ref QueryParameter queryParams, string errorDesc)
        {
            if (queryParams.IsNotNullAndEmpty())
            {
                if (queryParams.ValidationErrors.IsNullOrEmpty())
                {
                    queryParams.ValidationErrors = new List<string>();
                }

                queryParams.ValidationErrors.Add(errorDesc);
            }
        }
        #endregion
    }
}
