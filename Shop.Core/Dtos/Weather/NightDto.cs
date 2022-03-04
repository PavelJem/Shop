using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Core.Dtos.Weather
{
    public class NightDto
    {
        [JsonProperty("Icon")]
        public int Icon { get; set; }
        [JsonProperty("IconPhrase")]
        public string IconPhrase { get; set; }
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
        public WindDto Wind { get; set; }
        public WindGustDto WindGust { get; set; }
        public TotalLiquidDto TotalLiquid { get; set; }
        public RainDto Rain { get; set; }
        public SnowDto Snow { get; set; }
        public IceDto Ice { get; set; }
        [JsonProperty("HoursOfPrecipitation")]
        public float HoursOfPrecipitation { get; set; }
        [JsonProperty("HoursOfRain")]
        public float HoursOfRain { get; set; }
        [JsonProperty("CloudCover")]
        public int CloudCover { get; set; }
        public EvapotranspirationDto Evapotranspiration { get; set; }
        public SolarIrradianceDto SolarIrradiance { get; set; }
        [JsonProperty("Sources")]
        public string Sources { get; set; }
        [JsonProperty("MobileLink")]
        public string MobileLink { get; set; }
        [JsonProperty("Link")]
        public string Link { get; set; }
    }
}
