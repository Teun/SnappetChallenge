using System.Threading.Tasks;

namespace RReporter.Application.StoreWorkEvent
{
    public interface IWorkEventHandler
    {
        Task HandleAsync (WorkEventDto workEvent);
    }
}