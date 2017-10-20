using System.Threading.Tasks;

namespace XFRealmSqlite.Interfaces
{
    public interface IMessageService
    {
        Task ShowAsync(string title, string message);
    }
}
