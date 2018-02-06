using System;
using System.Collections.Generic;
using System.Text;

using DataRepositories.Data;

namespace DataRepositories.Interfaces
{
    /// <summary>
    /// The interface to the functionality to load answer data from a JSON file
    /// </summary>
    public interface IAnswerDataJsonFileLoader
    {
        /// <summary>
        /// Loads the answer data from a JSON file
        /// </summary>
        /// <remarks>
        /// In the interests of time, this method assumes that the file is a valid JSON file
        /// and that the necessary attributes are present in each record.
        /// </remarks>
        /// <param name="fileName">The name of the file to be loaded</param>
        /// <returns>The loaded data or an empty list if the file did not contain data</returns>
        List<Answer> LoadAnswerDataFromFile(string fileName);
    }
}
