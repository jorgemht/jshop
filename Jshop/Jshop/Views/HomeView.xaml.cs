using Jshop.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jshop.Views
{
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