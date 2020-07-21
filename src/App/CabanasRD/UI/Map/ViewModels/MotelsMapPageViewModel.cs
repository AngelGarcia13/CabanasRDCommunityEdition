using System;
using System.Collections.ObjectModel;
using System.Linq;
using CabanasRD.UI.Map.Models;
using CabanasRD.UI.ViewModels;
using CabanasRD.UseCases.Motels;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms.GoogleMaps;

namespace CabanasRD.UI.Map.ViewModels
{
    public class MotelsMapPageViewModel : ViewModelBase
    {
        public ObservableCollection<MotelLocation> Locations { get; set; }
        private readonly GetAllMotels _getAllMotels;
        private readonly string markerIcon = "marker.png";

        public MotelsMapPageViewModel(INavigationService navigationService, GetAllMotels getAllMotels)
            : base(navigationService)
        {
            _getAllMotels = getAllMotels;
            Title = "Cabañas";
            Locations = new ObservableCollection<MotelLocation>();
            LoadMotelsLocations();
        }


        private async void LoadMotelsLocations()
        {

            foreach (var item in await _getAllMotels.Invoke())
            {
                //TODO: [Enhancement] Map from Domain to UI Model using AutoMapper
                Locations.Add(new MotelLocation
                {
                    Position = new Position(item.Latitude, item.Longitude),
                    Motel = item,
                    Icon = BitmapDescriptorFactory.FromBundle(markerIcon)
                });
            }

        }

        public void InfoWindowSelected(Pin pin)
        {
            var motelDetails = Locations.FirstOrDefault(l => l.Motel.Name == pin.Label && l.Position.Equals(pin.Position));
            var navParams = new NavigationParameters();
            navParams.Add("MotelDetails", motelDetails.Motel);
            NavigationService.NavigateAsync("MotelDetailsPage", navParams);
        }

    }
}