using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.OpenWeather
{
    public class OpenCityViewModel
    {
        public string name { get; set; }
        public string main { get; set; }
        public float temp { get; set; }
        public float feels_like { get; set; }
        public Int64 pressure { get; set; }
        public int humidity { get; set; }
        public float speed { get; set; }
    }
}
