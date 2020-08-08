using System;
using System.Collections.Generic;
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
        private IList<MotelLocation> searchResultLocations;
        public IList<MotelLocation> SearchResultLocations
        {
            get { return searchResultLocations; }
            set { SetProperty(ref searchResultLocations, value); }
        }
        public ObservableCollection<Pin> Pins { get; set; }
        public DelegateCommand TextSearchChangedCommand { get; private set; }

        private const string addressLabel = "(Presione para ver detalles)";
        private readonly GetAllMotels _getAllMotels;
        private readonly string markerIcon = "marker.png";

        private bool isSearching;
        public bool IsSearching
        {
            get { return isSearching; }
            set { SetProperty(ref isSearching, value); }
        }

        private Pin selectedPin;
        public Pin SelectedPin
        {
            get { return selectedPin; }
            set { SetProperty(ref selectedPin, value); }
        }

        private string searchText = "";
        public string SearchText
        {
            get { return searchText; }
            set
            {
                SetProperty(ref searchText, value);
            }
        }
        
        private MotelLocation selectedLocation;
        public MotelLocation SelectedLocation
        {
            get { return selectedLocation; }
            set {
                SetProperty(ref selectedLocation, value);
                if (selectedLocation != null)
                {
                    SelectedPin = selectedLocation.Pin;
                    IsSearching = false;
                }
            }
        }
        

        public MotelsMapPageViewModel(INavigationService navigationService, GetAllMotels getAllMotels)
            : base(navigationService)
        {
            _getAllMotels = getAllMotels;
            Title = "Cabañas";
            Locations = new ObservableCollection<MotelLocation>();
            Pins = new ObservableCollection<Pin>();
            SearchResultLocations = new List<MotelLocation>();
            TextSearchChangedCommand = new DelegateCommand(TextSearchChanged);
            LoadMotelsLocations();
        }

        private void TextSearchChanged()
        {
            if (SearchText.Length > 0)
            {
                SelectedLocation = null;
                IsSearching = true;
                var results = Locations.Where(l => l.Motel.Name.ToUpper().Contains(SearchText.ToUpper())).ToList();
                SearchResultLocations = results;
            }
            else
            {
                IsSearching = false;
            }
        }

        //TODO: [Enhancement] Avoid async void calls!
        private async void LoadMotelsLocations()
        {

            foreach (var item in await _getAllMotels.Invoke())
            {
                var pinItem = new Pin
                {
                    Position = new Position(item.Latitude, item.Longitude),
                    Icon = BitmapDescriptorFactory.FromBundle(markerIcon),
                    Label = item.Name,
                    Address = addressLabel
                };
                //TODO: [Enhancement] Map from Domain to UI Model using AutoMapper
                Locations.Add(new MotelLocation
                {
                    Pin = pinItem,
                    Motel = item
                });
                
                Pins.Add(pinItem);
            }

        }

        public void InfoWindowSelected(Pin pin)
        {
            var motelDetails = Locations.FirstOrDefault(l => l.Pin.Equals(pin));
            var navParams = new NavigationParameters();
            navParams.Add("MotelDetails", motelDetails.Motel);
            NavigationService.NavigateAsync("MotelDetailsPage", navParams);
        }

    }
}