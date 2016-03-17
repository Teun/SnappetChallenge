using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

using System.Threading.Tasks;
using System.ServiceModel.Activation;


namespace sc2
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        
        static readonly IRepository answersRepository = new AnswersRepository();


        public IEnumerable<SubmittedAnswer> GetTodaysAnswers()
        {
            


            List<SubmittedAnswer> result = new List<SubmittedAnswer>();
            Task<List<BsonDocument>> t = answersRepository.GetTodaysAnswers();
            t.Wait();
            List<BsonDocument> BsonResults = t.Result;
            BsonResults.ForEach(r => result.Add(new SubmittedAnswer(r)));
            return result;
        }


        public IEnumerable<SubmittedAnswer> GetAnswersSubmittedBy(String strId)
        {
            int intId;// = 40281;
            if (!int.TryParse(strId, out intId))
                return null;

            List<SubmittedAnswer> result = new List<SubmittedAnswer>();
            Task<List<BsonDocument>> r = answersRepository.GetAnswersSubmittedBy(intId);
            r.Wait();
            List<BsonDocument> BsonResults = r.Result;
            BsonResults.ForEach(s => result.Add(new SubmittedAnswer(s)));
            return result;
        }

    }
}
