using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using MongoDB.Bson;

namespace sc2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "submittedanswer/today", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<SubmittedAnswer> GetTodaysAnswers();
        
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "submittedanswer/user/{id}", ResponseFormat=WebMessageFormat.Json)]
        IEnumerable<SubmittedAnswer> GetAnswersSubmittedBy(String id);


       

    }


    [DataContract]
    public class SubmittedAnswer 
    {
        private int _SubmittedAnswerId;
        private String _SubmitDateTime;
        private int _Correct;
        private int _Progress;
        private int _UserId;
        private int _ExerciseId;
        private double _Difficulty;
        private string _Subject;
        private string _Domain;
        private string _LearningObjective;

        [DataMember]
        public int SubmittedAnswerId
        {
            get { return _SubmittedAnswerId; }
            set { _SubmittedAnswerId = value; }
        }
        [DataMember]
        public String SubmitDateTime
        {
            get { return _SubmitDateTime; }
            set { _SubmitDateTime = value; }
        }
        [DataMember]
        public int Correct
        {
            get { return _Correct; }
            set { _Correct = value; }
        }
        [DataMember]
        public int Progress
        {
            get { return _Progress; }
            set { _Progress = value; }
        }
        [DataMember]
        public int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        [DataMember]
        public int ExerciseId
        {
            get { return _ExerciseId; }
            set { _ExerciseId = value; }
        }
        [DataMember]
        public double Difficulty
        {
            get { return _Difficulty; }
            set { _Difficulty = value; }
        }
        [DataMember]
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }
        [DataMember]
        public string Domain
        {
            get { return _Domain; }
            set { _Domain = value; }
        }
        [DataMember]
        public string LearningObjective
        {
            get { return _LearningObjective; }
            set { _LearningObjective = value; }
        }


        public SubmittedAnswer() { }

        public SubmittedAnswer(BsonDocument data)
        {
            try { 
                this.SubmittedAnswerId = (int)data["SubmittedAnswerId"];
                this.SubmitDateTime = data["SubmitDateTime"].ToString();
                this.Correct = (int)data["Correct"];
                this.Progress = (int)data["Progress"];
                this.UserId = (int)data["UserId"];
                this.ExerciseId = (int)data["ExerciseId"];
                this.Difficulty = Convert.ToDouble( data["Difficulty"]);
                this.Subject = data["Subject"].ToString();
                this.Domain = data["Domain"].ToString();
                this.LearningObjective = data["LearningObjective"].ToString();
            }
            catch(Exception e)
            {

            }
        }
    }
}
