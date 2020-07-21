using System;
using System.Collections.Generic;
using System.Reflection;
using CabanasRD.UI.Map.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace CabanasRD.UI.Map.Views
{
    public partial class MotelsMapPage : ContentPage
    {
        public MotelsMapPage()
        {
            InitializeComponent();
            AddMapStyle();
        }

        void AddMapStyle()
        {
            var assembly = typeof(MotelsMapPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"CabanasRD.GoogleMapStyles.json");
            string styleFile;
            using (var reader = new System.IO.StreamReader(stream))
            {
                styleFile = reader.ReadToEnd();
            }

            MotelsMap.MapStyle = MapStyle.FromJson(styleFile);
        }

        void InfoWindowClicked(System.Object sender, Xamarin.Forms.GoogleMaps.InfoWindowClickedEventArgs e)
        {
            ((MotelsMapPageViewModel)this.BindingContext).InfoWindowSelected(e.Pin);
        }
    }
}
