namespace Jshop.Views
{
    using System.Collections.Generic;
    using Jshop.CustomControl;
    using Jshop.ViewModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;

    public partial class StoreView : ContentPage
    {
        public StoreView(long id)
        {
            InitializeComponent();
            BindingContext = new StoreViewModel(id);

            MoveMapToCurrentPosition(new Position(40.416912, -3.703429));
        }

        private void MoveMapToCurrentPosition(Position position)
        {
            var pin = new CustomPin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Grocery Joe's",
                Address = "Calle del Pez",
                Id = "Xamarin"
            };

            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin);

            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1.0)));
        }
    }
}
