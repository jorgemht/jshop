using Jshop.Droid.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(LanguageService))]
namespace Jshop.Droid.Interface
{
    using Android.Content;
    using Android.OS;
    using Android.Preferences;
    using Java.Util;
    using Jshop.Interface;
    using System;
    using System.Threading;
    using Plugin.CurrentActivity;

    public class LanguageService : ILanguageService
    {
        public void ChangeLanguage(string lang)
        {
            if (Android.App.Application.Context.Resources.Configuration.Locale.Language == "es") ChangeLang(Android.App.Application.Context, lang);
            else if (Android.App.Application.Context.Resources.Configuration.Locale.Language == "en") ChangeLang(Android.App.Application.Context, lang);
            else ChangeLang(Android.App.Application.Context, lang);

            CrossCurrentActivity.Current.Activity.Recreate();
        }

        public static ContextWrapper ChangeLang(Context context, String lang_code)
        {

            var sharedPref = PreferenceManager.GetDefaultSharedPreferences(context);
            var editor = sharedPref.Edit();
            editor.PutString("lang", lang_code);
            editor.Commit();

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang_code);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang_code);

            Locale sysLocale;
            Context result = context;

            var rs = context.Resources;
            var config = rs.Configuration;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
            {
                sysLocale = config.Locales.Get(0);
            }
            else
            {
                sysLocale = config.Locale;
            }
            if (!lang_code.Equals("") && !sysLocale.Language.Equals(lang_code))
            {
                Locale locale = new Locale(lang_code);
                Locale.Default = (locale);
                if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
                {
                    config.Locale = (locale);
                }
                else
                {
                    config.Locale = locale;
                }
                if (Build.VERSION.SdkInt >= BuildVersionCodes.JellyBeanMr1)
                {
                    result = context.CreateConfigurationContext(config);
                }
                else
                {
                    context.Resources.UpdateConfiguration(config, context.Resources.DisplayMetrics);
                }
            }

            return new ContextWrapper(result);
        }
    }
}