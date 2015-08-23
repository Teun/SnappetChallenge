﻿namespace SnappetChallenge.DAL.Entities
{
    using System;

    public class Answer : BaseEntity
    {
        public long StudentId { get; set; }

        public long ExerciseId { get; set; }

        public long SourceId { get; set; }

        public bool Correct { get; set; }

        public DateTime SubmitDateTime { get; set; }

        public double Progress { get; set; }

        public virtual Exercise Exercise { get; set; }

        public virtual Student Student { get; set; }
    }
}