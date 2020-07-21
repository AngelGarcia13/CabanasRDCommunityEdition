using System;
using CabanasRD.Domain.Motels;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace CabanasRD.UI.Map.Models
{
    public class MotelLocation
    {
        public Motel Motel { get; set; }
        public Position Position { get; set; }
        public BitmapDescriptor Icon { get; set; }
    }
}
