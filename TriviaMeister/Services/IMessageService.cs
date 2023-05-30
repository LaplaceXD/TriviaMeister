using System.Threading.Tasks;

namespace TriviaMeister.Services
{
    public interface IMessageService
    {
        Task ShowAsync(string title, string message, string cancel);
    }
}
