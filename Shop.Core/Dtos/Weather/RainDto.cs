using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Core.Dtos.Weather
{
    public class RainDto
    {
        [JsonProperty("Value")]
        public double Value { get; set; }
        [JsonProperty("Unit")]
        public string Unit { get; set; }
        [JsonProperty("UnitType")]
        public int UnitType { get; set; }
    }
}
