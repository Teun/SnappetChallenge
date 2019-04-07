using System.Collections.Generic;
using System.Threading.Tasks;
using RReporter.Application.Domain;

namespace RReporter.Application.StoreWorkEvent.Depends
{
    public interface IStoreWorkEvents
    {
        Task StoreAsync (WorkEvent workEvent);

    }
}