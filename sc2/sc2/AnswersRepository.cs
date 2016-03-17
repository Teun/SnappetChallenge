using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

using System.Threading.Tasks;

namespace sc2
{
    public class AnswersRepository : IRepository
    {
        private static IMongoClient _client;
        private static IMongoDatabase _database;


        public async Task<List<BsonDocument>> GetTodaysAnswers()
        {
            List<BsonDocument> result = null;
            _client = new MongoClient();
            _database = _client.GetDatabase("answers");
            var collection = _database.GetCollection<BsonDocument>("answerList");
            //String today = DateTime.Today.ToString("yyyy-MM-dd");
            //var filter = Builders<BsonDocument>.Filter.Regex("SubmitDateTime", new BsonRegularExpression(today));
            var filter = Builders<BsonDocument>.Filter.Regex("SubmitDateTime", new BsonRegularExpression("2015-03-02"));
            result = await collection.Find(filter).ToListAsync();
            return result;
        }

        public async Task<List<BsonDocument>> GetAnswersSubmittedBy(int userId) 
        {
            List<BsonDocument> result = null;
            _client = new MongoClient();
            _database = _client.GetDatabase("answers");
            var collection = _database.GetCollection<BsonDocument>("answerList");
            //var filter = new BsonDocument();
            var filter = Builders<BsonDocument>.Filter.Eq("UserId", userId);
            result = await collection.Find(filter).ToListAsync();
            return result;
        }
    }
}