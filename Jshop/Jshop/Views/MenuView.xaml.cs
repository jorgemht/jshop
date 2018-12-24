namespace Jshop.Views
{
    using Jshop.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuView : ContentPage
	{
		public MenuView ()
		{
			InitializeComponent ();

            BindingContext = new MenuViewModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var safeInsets = On<Xamarin.Forms.PlatformConfiguration.iOS>().SafeAreaInsets();
            safeInsets.Bottom = 0;
            this.Padding = safeInsets;
        }
    }
}