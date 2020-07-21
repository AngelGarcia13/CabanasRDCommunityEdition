using System;
using System.Collections.Generic;

namespace CabanasRD.Domain.Motels
{
    public class Motel
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; }
        public List<MotelImage> Images { get; set; }
        public List<MotelService> Services { get; set; }
        public List<MotelPhone> Phones { get; set; }
    }
}
