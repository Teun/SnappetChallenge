using Microsoft.AspNetCore.Http;
using SnappedChallengeApi.Models.Commons.ApiCommons;
using SnappedChallengeApi.Models.Constants;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnappedChallengeApi._Corelib.Extensions
{
    /// <summary>
    /// Simple extensions for exercise practical functionalty need
    /// </summary>
    public static class HttpExtensions
    {
        /// <summary>
        /// Swagger Attribute parse extension
        /// </summary>
        /// <typeparam name="TAttr"></typeparam>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IEnumerable<TAttr> GetAllAttrs<TAttr>(this OperationFilterContext context)
            where TAttr : Attribute
        {
            var controllerAttrs = context.ApiDescription.ControllerAttributes().OfType<TAttr>();
            var actionAttrs = context.ApiDescription.ActionAttributes().OfType<TAttr>();
            var result = controllerAttrs.Union(actionAttrs).Distinct();
            return result;
        }

        /// <summary>
        /// Http request url builder
        /// </summary>
        /// <param name="serviceUrl"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public static string GetRequestUrl(this string serviceUrl, string route)
        {
            return $"{serviceUrl}{route}";
        }

        /// <summary>
        /// Query string parser from the http context
        /// </summary>
        /// <param name="context"></param>
        /// <param name="defaultRecordCount"></param>
        /// <returns></returns>
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
                throw ex;
            }
        }

        #region Other internal helpers
        /// <summary>
        /// Other Query Parameter internal parser
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="pairItem"></param>
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
                throw ex;
            }
        }
        /// <summary>
        /// WithCount Query Parameter internal parser
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="pairItem"></param>
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
        /// <summary>
        /// Count Query Parameter internal parser
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="pairItem"></param>
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
        /// <summary>
        /// Lang Parameter internal parser
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="pairItem"></param>
        private static void ParseLangParameter(ref QueryParameter parameters, KeyValuePair<string, string> pairItem)
        {
            parameters.Language = pairItem.Value;

            if (parameters.Language.IsNotNullAndEmpty())
            {
                parameters.Language = ServiceConstants.DefaultLanguageCode;
            }
        }
        /// <summary>
        /// Limit Parameter internal parser
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="pairItem"></param>
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
        /// <summary>
        /// First Parameter internal parser
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="pairItem"></param>
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
        /// <summary>
        /// Last Parameter internal parser
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="pairItem"></param>
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
        /// <summary>
        /// Offset Parameter internal parser
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="pairItem"></param>
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
        /// <summary>
        /// Sort Parameter internal parser
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="pairItem"></param>
        private static void ParseSortParameter(ref QueryParameter parameters, KeyValuePair<string, string> pairItem)
        {
            if (!string.IsNullOrEmpty(pairItem.Value))
            {
                parameters.SortExpression = pairItem.Value;
            }
        }
        /// <summary>
        /// Validation Error Parameter internal parser
        /// </summary>
        /// <param name="queryParams"></param>
        /// <param name="errorDesc"></param>
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
