namespace Jshop.Views
{
    using ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{
		public HomeView ()
		{
			InitializeComponent ();

            BindingContext = new HomeViewModel();
		}
	}
}   