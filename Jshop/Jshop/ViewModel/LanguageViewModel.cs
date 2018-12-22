namespace Jshop.ViewModel
{
    using Jshop.Helpers;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LanguageViewModel
    {

        public ICommand ChangeEnglishLanguageCommand => new Command(ChangeEnglishLanguage);
        public ICommand ChangeSpanishLanguageCommand => new Command(ChangeSpanishLanguage);

        private void ChangeEnglishLanguage()
        {
            Language.UpdateLanguage("en");
            MainViewModel.GetInstance().NavigationService.SetMainPage();
        }

        private void ChangeSpanishLanguage()
        {
            Language.UpdateLanguage("es");
            MainViewModel.GetInstance().NavigationService.SetMainPage();
        }
    }
}
