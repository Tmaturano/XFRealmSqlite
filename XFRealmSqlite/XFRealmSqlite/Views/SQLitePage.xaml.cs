
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFRealmSqlite.ViewModels;

namespace XFRealmSqlite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLitePage : ContentPage
    {
        public SQLitePage()
        {
            InitializeComponent();
            BindingContext = new SQLitePageViewModel();
        }
    }
}