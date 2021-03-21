namespace Snappet.Models.Database
{
    /// <summary>
    /// Database query result
    /// </summary>
    public class DBResult
    {
        /// <summary>
        /// The query result. It could be a list or just a simple Id
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// All record count by the current condition. This fields will be used in the paging.
        /// </summary>
        public int ActualSize { get; set; }

        /// <summary>
        /// Based on the standard RESTful status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// If there is any error, this field contains the error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        public DBResult()
        {
        }

        /// <summary>
        /// Initialize fields based on the parameters.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="errorMessage"></param>
        /// <param name="data"></param>
        /// <param name="actualSize"></param>
        public DBResult(int statusCode, string errorMessage, object data = null, int actualSize = 0)
        {
            this.StatusCode = statusCode;
            this.ErrorMessage = errorMessage;

            this.Data = data;
            if (actualSize >= 0)
                this.ActualSize = actualSize;
            else
                this.ActualSize = data == null ? 0 : 1;
        }
    }
}
