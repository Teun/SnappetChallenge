using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Driver; 


namespace sc2
{
    interface IRepository
    {
        Task<List<BsonDocument>> GetTodaysAnswers();

        Task<List<BsonDocument>> GetAnswersSubmittedBy(int userId);

    }
}
