using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Dtos.OpenWeathers
{
    public class OpenMainDto
    {
        [JsonProperty("temp")]
        public float temp { get; set; }
        [JsonProperty("feels_like")]
        public float feels_like { get; set; }
        [JsonProperty("pressure")]
        public Int64 pressure { get; set; }
        [JsonProperty("humidity")]
        public int humidity { get; set; }
    }
}
