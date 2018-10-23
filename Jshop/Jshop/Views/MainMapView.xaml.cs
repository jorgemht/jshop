namespace Jshop.Views
{
    using System.Collections.Generic;
    using Jshop.CustomControl;
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;

    public partial class MainMapView : ContentPage
    {
        public MainMapView()
        {
            InitializeComponent();

            var pin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(40.423823, -3.705489),
                Label = "Grocery Joe's",
                Address = "Calle del Pez",
                Id = "Xamarin"
            };

            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(40.416912, -3.703429), Distance.FromMiles(1.0)));
        }
    }
}
