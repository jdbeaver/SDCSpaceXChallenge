using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceXSolution.Models
{

    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class SpaceXLaunchPad
    {
        public int Padid { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Full_name { get; set; }
        public string Status { get; set; }
        public Location Location { get; set; }
        public List<string> Vehicles_launched { get; set; }
        public int Attempted_launches { get; set; }
        public int Successful_launches { get; set; }
        public string Wikipedia { get; set; }
        public string Details { get; set; }
    }
}
