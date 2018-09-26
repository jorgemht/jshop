using Jshop.Droid.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformCultureInfo))]
namespace Jshop.Droid.Interface
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