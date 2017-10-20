using System.Threading.Tasks;
using XFRealmSqlite.Interfaces;

namespace XFRealmSqlite.Services
{
    public class MessageService : IMessageService
    {
        public async Task ShowAsync(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "Ok");
        }
    }
}
