
namespace Jshop.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;

    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        private const string AccessTokenKey = "accessTokenKey_key";
        private static readonly string AccessTokenDefault = string.Empty;

        private const string LangKey = "lang_Key";
        private static readonly string LangKeyDefault = string.Empty;

        public static string AccessToken
        {
            get => AppSettings.GetValueOrDefault(AccessTokenKey, AccessTokenDefault);
            set => AppSettings.AddOrUpdateValue(AccessTokenKey, value);
        }

        public static string Lang
        {
            get => AppSettings.GetValueOrDefault(LangKey, LangKeyDefault);
            set => AppSettings.AddOrUpdateValue(LangKey, value);
        }
    }
}
