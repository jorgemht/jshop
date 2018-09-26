using Foundation;
using Xamarin.Forms;
using Jshop.Interface;
using Jshop.iOS.Interface;

[assembly: Dependency(typeof(LanguageService))]
namespace Jshop.iOS.Interface
{
    public class LanguageService : ILanguageService
    {
        public void ChangeLanguage(string lang)
        {
            NSUserDefaults.StandardUserDefaults.SetValueForKey(NSArray.FromStrings(lang, NSLocale.CurrentLocale.LanguageCode), new NSString("AppleLanguages"));
            NSUserDefaults.StandardUserDefaults.Synchronize();
        }
    }
}