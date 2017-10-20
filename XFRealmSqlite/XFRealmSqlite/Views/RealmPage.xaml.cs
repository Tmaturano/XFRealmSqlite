
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFRealmSqlite.ViewModels;

namespace XFRealmSqlite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RealmPage : ContentPage
    {
        public RealmPage()
        {
            InitializeComponent();
            BindingContext = new RealmPageViewModel();
        }
    }
}