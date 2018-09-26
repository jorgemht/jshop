using Jshop.iOS.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(LanguageService))]
namespace Jshop.iOS.Interface
{
    using Jshop.Interface;
    using System.Globalization;
    using System.Threading;

    public class PlatformCultureInfo : ICultureInfo
    {
        public CultureInfo CurrentCulture
        {
            get => Thread.CurrentThread.CurrentCulture;
            set => Thread.CurrentThread.CurrentCulture = value;
        }

        public CultureInfo CurrentUICulture
        {
            get => Thread.CurrentThread.CurrentUICulture;
            set => Thread.CurrentThread.CurrentUICulture = value;
        }
    }
}