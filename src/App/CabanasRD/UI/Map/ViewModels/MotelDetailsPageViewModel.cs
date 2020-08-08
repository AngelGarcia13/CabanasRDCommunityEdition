using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CabanasRD.Domain.Motels;
using CabanasRD.UI.ViewModels;
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
            //TODO: Get the current user's position and calculate distance
            Distance = "1.2 KMs";
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