using System;
using System.Collections.Generic;
using System.Linq;

using DataRepositories.Data;
using DataRepositories.Interfaces;

namespace DataRepositories.Implementations
{
    /// <summary>
    /// Provides an implementation of our simple in-memory answer database
    /// </summary>
    public class AnswerDB : IAnswerDB
    {
        private List<Answer> answerData = null;
        private IAnswerDataJsonFileLoader fileLoader = null;
        private string dataFileName = null;

        /// <summary>
        /// Constructs an instance of AnswerDB
        /// </summary>
        /// <remarks>
        /// The data file will not be loaded right way. It will be lazy loaded when
        /// the queryable is first retrieved.
        /// </remarks>
        /// <param name="fileLoader">An instance of an answer data file loader</param>
        /// <param name="dataFileName">The data file to be loaded into the database</param>
        public AnswerDB(IAnswerDataJsonFileLoader fileLoader, string dataFileName)
        {
            this.fileLoader = fileLoader;
            this.dataFileName = dataFileName;
        }

        /// <see cref="IAnswerDB.GetAnswerQueryable"/>
        public IQueryable<Answer> GetAnswerQueryable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads the answer data from the data file
        /// </summary>
        private void LoadDataFile()
        {
            answerData = fileLoader.LoadAnswerDataFromFile(dataFileName);
        }
    }
}
