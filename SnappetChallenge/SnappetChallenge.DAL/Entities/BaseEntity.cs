namespace SnappetChallenge.DAL.Entities
{
    using System;

    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
