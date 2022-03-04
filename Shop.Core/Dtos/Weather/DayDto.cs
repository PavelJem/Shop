using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Core.Dtos.Weather
{
    public class DayDto
    {
        [JsonProperty("Icon")]
        public int Icon { get; set; }
        [JsonProperty("IconPhrase")]
        public string IconPhrase { get; set; }
        [JsonProperty("LocalSource")]
        public LocalSourceDto LocalSource { get; set; }
        [JsonProperty("HasPrecipitation")]
        public bool HasPrecipitation { get; set; }
        [JsonProperty("PrecipitationType")]
        public string PrecipitationType { get; set; }
        [JsonProperty("PrecipitationIntensity")]
        public string PrecipitationIntensity { get; set; }
        [JsonProperty("ShortPhrase")]
        public string ShortPhrase { get; set; }
        [JsonProperty("LongPhrase")]
        public string LongPhrase { get; set; }
        [JsonProperty("PrecipitationProbability")]
        public int PrecipitationProbability { get; set; }
        [JsonProperty("ThunderstormProbability")]
        public int ThunderstormProbability { get; set; }
        [JsonProperty("RainProbability")]
        public int RainProbability { get; set; }
        [JsonProperty("SnowProbability")]
        public int SnowProbability { get; set; }
        [JsonProperty("IceProbability")]
        public int IceProbability { get; set; }
        [JsonProperty("Wind")]
        public WindDto Wind { get; set; }
        [JsonProperty("WindGust")]
        public WindGustDto WindGust { get; set; }
        [JsonProperty("TotalLiquid")]
        public TotalLiquidDto TotalLiquid { get; set; }
        [JsonProperty("Rain")]
        public RainDto Rain { get; set; }
        [JsonProperty("Snow")]
        public SnowDto Snow { get; set; }
        [JsonProperty("Ice")]
        public IceDto Ice { get; set; }
        [JsonProperty("HoursOfPrecipitation")]
        public float HoursOfPrecipitation { get; set; }
        [JsonProperty("HoursOfRain")]
        public float HoursOfRain { get; set; }
        [JsonProperty("CloudCover")]
        public int CloudCover { get; set; }
        public EvapotranspirationDto Evapotranspiration { get; set; }
        public SolarIrradianceDto SolarIrradiance { get; set; }
    }
}
