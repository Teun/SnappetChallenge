using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

using DataRepositories.Data;
using DataRepositories.Interfaces;

namespace DataRepositories.Implementations
{
    public class AnswerDataJsonFileLoader : IAnswerDataJsonFileLoader
    {
        /// <see cref="IAnswerDataJsonFileLoader.LoadAnswerDataFromFile(string)"/>
        public List<Answer> LoadAnswerDataFromFile(string fileName)
        {
            //Read the JSON text from the file
            string jsonData = File.ReadAllText(fileName);

            //Deserialize the JSON
            List<Answer> answerData = JsonConvert.DeserializeObject<List<Answer>>(jsonData);

            return answerData;
        }
    }
}
