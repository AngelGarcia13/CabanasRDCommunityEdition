using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using CabanasRD.Domain.Motels;
using CabanasRD.Extensions;
using CabanasRD.Messages;
using CabanasRD.UI.Map.Models;
using CabanasRD.UI.ViewModels;
using CabanasRD.UseCases.Motels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms.GoogleMaps;

namespace CabanasRD.UI.Map.ViewModels
{
    public class MotelsMapPageViewModel : ViewModelBase
    {
        public ObservableCollection<MotelLocation> Locations { get; set; }
        public IReadOnlyList<Motel> Motels { get; set; }
        private IList<MotelLocation> searchResultLocations;
        private IPageDialogService _dialogService;
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
            set
            {
                SetProperty(ref selectedLocation, value);
                if (selectedLocation != null)
                {
                    SelectedPin = selectedLocation.Pin;
                    IsSearching = false;
                }
            }
        }


        public MotelsMapPageViewModel(INavigationService navigationService, IPageDialogService dialogService, GetAllMotels getAllMotels)
            : base(navigationService)
        {
            _getAllMotels = getAllMotels;
            _dialogService = dialogService;
            Title = "Cabañas";
            Locations = new ObservableCollection<MotelLocation>();
            Motels = new List<Motel>();
            Pins = new ObservableCollection<Pin>();
            SearchResultLocations = new List<MotelLocation>();
            TextSearchChangedCommand = new DelegateCommand(TextSearchChanged);
            LoadMotelsLocations().Await(Completed, ErrorHandler);
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
        private async Task LoadMotelsLocations()
        {
            IsBusy = true;
            try
            {
                using (UserDialogs.Instance.Loading(Informations.Loading, null, null, true))
                {
                    // TODO: Add an activity indicator while loading the information
                    Motels = await _getAllMotels.Invoke();
                }

            }
            catch (Exception exception)
            {
                // TODO: Register Crash and Exceptions into AppCenter
                Console.WriteLine(exception.Message);

                var dialogServiceResult = await _dialogService
                    .DisplayAlertAsync
                    (
                        CommonDisplayAlertMessages.Warning,
                        Messages.Warning.ThereIsAnErrorGettingTheInformationFromTheServer,
                        CommonDisplayAlertMessages.TryAgain,
                        CommonDisplayAlertMessages.No
                    );

                if (dialogServiceResult)
                {
                    await LoadMotelsLocations();
                }
                return;
            }
        }

        public void InfoWindowSelected(Pin pin)
        {
            var motelDetails = Locations.FirstOrDefault(l => l.Pin.Equals(pin));
            var navParams = new NavigationParameters
            {
                { "MotelDetails", motelDetails.Motel }
            };
            NavigationService.NavigateAsync("MotelDetailsPage", navParams);
        }

        private void Completed()
        {
            IsBusy = false;
            foreach (var item in Motels)
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
        private void ErrorHandler(Exception exception)
        {
            IsBusy = false;
            _dialogService.DisplayAlertAsync
                (
                    CommonDisplayAlertMessages.Error,
                    Messages.Errors.IternarlServerError,
                    CommonDisplayAlertMessages.OK
                );

        }
    }
}