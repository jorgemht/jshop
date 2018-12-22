namespace Jshop.Views
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Jshop.CustomControl;
    using Plugin.Permissions;
    using Plugin.Permissions.Abstractions;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMapView : ContentPage
    {
        public MainMapView()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            await MoveMapToCurrentPosition();
            base.OnAppearing();
        }

        private async Task MoveMapToCurrentPosition()
        {
            Position position = new Position();

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

                if (status != PermissionStatus.Granted)
                {
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location)) status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    var userPosition = await Geolocation.GetLocationAsync();

                    position = new Position(userPosition.Latitude, userPosition.Longitude);
                    customMap.IsShowingUser = true;
                }
                else if (status != PermissionStatus.Unknown)
                {
                    position = new Position(40.416912, -3.703429);
                }
            }
            catch (Exception ex)
            {
                position = new Position(40.416912, -3.703429);
            }

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

            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1.0)));
        }
    }
}
