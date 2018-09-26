namespace Jshop.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;

    public class LanguageViewModel
    {

        public ICommand ChangeEnglishLanguageCommand => new RelayCommand(ChangeEnglishLanguage);
        public ICommand ChangeSpanishLanguageCommand => new RelayCommand(ChangeSpanishLanguage);

        private void ChangeEnglishLanguage()
        {
            MainViewModel.GetInstance().NavigationService.SetMainPage();
        }

        private void ChangeSpanishLanguage()
        {
            MainViewModel.GetInstance().NavigationService.SetMainPage();
        }
    }
}
