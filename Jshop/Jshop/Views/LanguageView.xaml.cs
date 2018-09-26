namespace Jshop.Views
{
    using Jshop.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguageView : ContentPage
    {
        public LanguageView()
        {
            InitializeComponent();

            BindingContext = new LanguageViewModel();
        }
    }
}