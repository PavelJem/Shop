using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Dtos.OpenWeather
{
    public class OpenWindDto
    {
        [JsonProperty("speed")]
        public float speed { get; set; }
    }
}
