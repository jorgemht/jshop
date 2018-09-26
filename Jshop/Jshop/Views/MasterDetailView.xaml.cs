namespace Jshop.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailView : MasterDetailPage
    {
        public MasterDetailView()
        {
            InitializeComponent();

            App.Master = this;
            App.Navigator = Navigator;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            App.Master = this;
            App.Navigator = Navigator;
        }
    }
}