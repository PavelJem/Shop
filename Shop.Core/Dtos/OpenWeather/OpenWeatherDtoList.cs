using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Dtos.OpenWeather
{
    public class OpenWeatherDtoList
    {
        [JsonProperty("main")]
        public string main { get; set; }
    }
}
