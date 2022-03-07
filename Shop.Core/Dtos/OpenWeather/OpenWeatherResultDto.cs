using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Dtos.OpenWeather
{
    public class OpenWeatherResultDto
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("main")]
        public string main { get; set; }
        [JsonProperty("temp")]
        public float temp { get; set; }
        [JsonProperty("feels_like")]
        public float feels_like { get; set; }
        [JsonProperty("pressure")]
        public Int64 pressure { get; set; }
        [JsonProperty("humidity")]
        public int humidity { get; set; }
        [JsonProperty("speed")]
        public float speed { get; set; }
    }
}
