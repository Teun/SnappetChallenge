using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SnappetChallenge
{

    public class SnappetChallenge : ISnappetChallenge
    {

        public Answer GetAnswer(string answerId)
        {
            Answer answer = SnappetDAL.GetAnswer(int.Parse(answerId));
            if (answer == null)
            {
                throw new FaultException("Answer not found");
            }
            return answer;
        }

        public List<Answer> GetDomainAnswersForDateTime(string UserID, string Domain, string Date, string Time)
        {
            string datetime = Date + Time;
            List<Answer> answers = SnappetDAL.GetDomainAnswersForDateTime(UserID, Domain, DateTime.ParseExact(datetime, "yyyyMMddHHmmss",null));
            if (answers == null)
            {
                throw new FaultException("Answers not found");
            }
            return answers;
        }

        public List<ProgressOverView> GetProgressOverViewDate(string Date, string Time)
        {
            string datetime = Date + Time;
            List<ProgressOverView> progress = SnappetDAL.GetProgressOverViewDate(DateTime.ParseExact(datetime, "yyyyMMddHHmmss", null));
            if (progress == null)
            {
                throw new FaultException("Answers not found");
            }
            return progress;
        }
    }
}
