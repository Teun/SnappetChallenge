using System.Collections.Generic;
using Snappet.Challenge.Web.Core.Models;

namespace Snappet.Challenge.Web.Data
{
    public interface IContext
    {
        IEnumerable<Work> Data { get; }
    }
}