using System;

namespace SnappetChallenge.Models.Contracts
{
    public interface ITimeRange
    {
        DateTime Start { get; set; }
        DateTime End { get; set; }
    }
}