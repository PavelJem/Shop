using Newtonsoft.Json;
using Shop.Core.Dtos.OpenWeathers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Dtos.OpenWeather
{
    public class OpenWeatherDto
    {
        public List<OpenWeatherDtoList> weather{ get; set; }
        public OpenMainDto main { get; set; }
        public OpenWindDto wind { get; set; }
        public string name { get; set; }
    }
}
