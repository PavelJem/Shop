using Nancy.Json;
using Shop.Core.Dtos.OpenWeather;
using Shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ApplicationServices.Services
{
    public class OpenWeatherForecastServices : IOpenWeatherServices
    {
        public async Task<OpenWeatherResultDto>OpenWeatherDetail(OpenWeatherResultDto dto)
        {
            string api_key = "c7135f49186f2a9e2dadbdac98742079";
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={dto.name}&limit=5&units=metric&appid={api_key}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                OpenWeatherDto weatherInfo = new JavaScriptSerializer().Deserialize<OpenWeatherDto>(json);

                dto.name = weatherInfo.name;
                dto.main = weatherInfo.weather[0].main;
                dto.temp = weatherInfo.main.temp;
                dto.feels_like = weatherInfo.main.feels_like;
                dto.pressure = weatherInfo.main.pressure;
                dto.humidity = weatherInfo.main.humidity;
                dto.speed = weatherInfo.wind.speed;

                var jsonString = new JavaScriptSerializer().Serialize(dto);
            }
            return dto;
        }
    }
}
