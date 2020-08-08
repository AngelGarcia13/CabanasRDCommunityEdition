using System;
using CabanasRD.Domain.Motels;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace CabanasRD.UI.Map.Models
{
    public class MotelLocation
    {
        public Motel Motel { get; set; }
        public Pin Pin { get; set; }
    }
}
