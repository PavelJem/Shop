using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Core.Dtos.Weather
{
    public class MoonDto
    {
        [JsonProperty("Rise")]
        public string Rise { get; set; }
        [JsonProperty("EpochRise")]
        public Int64 EpochRise { get; set; }
        [JsonProperty("Set")]
        public string Set { get; set; }
        [JsonProperty("EpochSet")]
        public Int64 EpochSet { get; set; }
        [JsonProperty("Phase")]
        public string Phase { get; set; }
        [JsonProperty("Age")]
        public int Age { get; set; }
    }
}
