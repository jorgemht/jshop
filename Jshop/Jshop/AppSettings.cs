namespace Jshop
{
    public static class AppSettings
    {
        public static string GithubUrl;
        public static string DefaultPhoto;
        public static string DefaultStoreEndpoint;

        static AppSettings()
        {
            GithubUrl = "https://github.com/jorgemht/Jshop";
            DefaultPhoto = "https://imgix.bustle.com/rehost/2016/9/13/448e1dea-fcbc-4f59-acab-25946e3e47ac.jpg?w=970&h=546&fit=crop&crop=faces&auto=format&q=70";
            DefaultStoreEndpoint = "";
        }

    }
}
