using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SnappetChallenge
{
    [ServiceContract]
    public interface ISnappetChallenge
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetProgressOverViewDate/{Date}/{Time}", ResponseFormat = WebMessageFormat.Json)]
        List<ProgressOverView> GetProgressOverViewDate(string Date, string Time);

        [OperationContract]
        [WebGet(UriTemplate = "GetDomainAnswersForDateTime/{UserID}/{Domain}/{Date}/{Time}", ResponseFormat = WebMessageFormat.Json)]
        List<Answer> GetDomainAnswersForDateTime(string UserID, string Domain, string Date, string Time);

        [OperationContract]
        [WebGet(UriTemplate = "GetAnswer/{answerId}", ResponseFormat = WebMessageFormat.Json)]
        Answer GetAnswer(string answerId);
    }


    [DataContract]
    public class Answer
    {
        [DataMember]
        public int SubmittedAnswerId { get; set; }

        [DataMember]
        public DateTime SubmitDateTime { get; set; }

        [DataMember]
        public string Correct { get; set; }

        [DataMember]
        public string Progress { get; set; }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string ExerciseId { get; set; }

        [DataMember]
        public string Difficulty { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string Domain { get; set; }

        [DataMember]
        public string LearningObjective { get; set; }
    }

    public class ProgressOverView
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public string Domain { get; set; }

        [DataMember]
        public int TotalProgress { get; set; }

    }
}
