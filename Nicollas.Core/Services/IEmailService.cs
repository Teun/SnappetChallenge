using System.Threading.Tasks;

namespace Nicollas.Core.Services
{
    public interface IEmailService
    {
        Task SendAsync(string destinationGroup, string subject, string body);
        void SendAway(string destinationGroup, string subject, string body);
    }
}
