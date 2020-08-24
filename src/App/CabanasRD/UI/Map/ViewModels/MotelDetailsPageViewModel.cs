using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CabanasRD.Domain.Motels;
using CabanasRD.UI.ViewModels;
using Microsoft.AppCenter.Analytics;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Essentials;

namespace CabanasRD.UI.Map.ViewModels
{
    public class MotelDetailsPageViewModel : ViewModelBase
    {
        public Motel Motel { get; set; }
        public ObservableCollection<MotelImage> Images { get; set; }
        public ObservableCollection<MotelPhone> Phones { get; set; }
        public ObservableCollection<MotelService> Services { get; set; }
        public DelegateCommand NavigateToLocationCommand { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        private string distance;
        public string Distance
        {
            get { return distance; }
            set { SetProperty(ref distance, value); }
        }
        public MotelDetailsPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Images = new ObservableCollection<MotelImage>();
            Services = new ObservableCollection<MotelService>();
            Phones = new ObservableCollection<MotelPhone>();
            NavigateToLocationCommand = new DelegateCommand(async () => await NavigateToLocation());
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            Motel = parameters.GetValue<Motel>("MotelDetails");
            Name = Motel.Name;
            //DONE: Get the current user's position and calculate distance 
            GetDistance(Motel);

            foreach (var item in Motel.Images)
            {
                Images.Add(item);
            }
            foreach (var item in Motel.Phones)
            {
                Phones.Add(item);
            }
            foreach (var item in Motel.Services)
            {
                Services.Add(item);
            }

            var analyticsData = new Dictionary<string, string> { { "Name", Motel.Name } };
            Analytics.TrackEvent("Motel selected", analyticsData);
        }
        public async void GetDistance(Motel motel)
        {
            try
            {
                //Get the current user's position
                var userLocation = await Geolocation.GetLastKnownLocationAsync();
                var fromLocation = new Location(userLocation.Latitude, userLocation.Longitude);
                var toLocation = new Location(motel.Latitude, motel.Longitude);
                //Calculate distance
                double distance = fromLocation.CalculateDistance(toLocation, DistanceUnits.Kilometers);
                Distance = $"{Math.Round(distance)} KMs";
            }
            catch (Exception ex)
            {
                // Handle exception when the distance is unknown
            }


        }
        public async Task NavigateToLocation()
        {
            var location = new Location(Motel.Latitude, Motel.Longitude);
            var options = new MapLaunchOptions { NavigationMode = Xamarin.Essentials.NavigationMode.Driving };

            try
            {
                await Xamarin.Essentials.Map.OpenAsync(location, options);
            }
            catch (Exception ex)
            {
                // No map application available to open or placemark can not be located
            }
        }
    }
}