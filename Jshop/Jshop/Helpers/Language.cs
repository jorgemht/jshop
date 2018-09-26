namespace Jshop.Helpers
{
    using Jshop.Interface;
    using Xamarin.Forms;

    public static class Language
    {
        public static void UpdateLanguage()
        {
            var cultureInfo = DependencyService.Get<ICultureInfo>().CurrentCulture;

            Settings.Lang = cultureInfo.TwoLetterISOLanguageName;

            DependencyService.Get<ILanguageService>().ChangeLanguage(Settings.Lang);
        }

        public static void UpdateLanguage(string lang)
        {
            Settings.Lang = lang;

            DependencyService.Get<ILanguageService>().ChangeLanguage(Settings.Lang);
        }
    }
}
