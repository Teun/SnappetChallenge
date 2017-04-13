// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="UserStatItem.cs" company="Noordhoff Uitgevers BV">
//      © Noordhoff Uitgevers BV, the Netherlands
//  </copyright>
//  <author>Valiukevich, Evgeny</author>
// --------------------------------------------------------------------------------------------------------------------
namespace Demo.Report.API.Model
{
    using System;

    public class UserWorkItem
    {
        public long UserId { get; set; }
        public long SubmittedAnswerId { get; set; }
        public long ExerciseId { get; set; }

        public int Correct { get; set; }
        public float Progress { get; set; }
        public string Difficulty { get; set; }

        public string Domain { get; set; }
        public string Subject { get; set; }
        public string LearningObjective { get; set; }

        public DateTime SubmitDateTime { get; set; }
    }
}