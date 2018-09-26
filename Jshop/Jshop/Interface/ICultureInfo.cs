namespace Jshop.Interface
{
    using System.Globalization;

    public interface ICultureInfo
    {
        CultureInfo CurrentCulture { get; set; }
        CultureInfo CurrentUICulture { get; set; }
    }
}
