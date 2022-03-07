using Microsoft.AspNetCore.Mvc;
using Shop.ApplicationServices.Services;
using Shop.Core.Dtos.OpenWeather;
using Shop.Core.ServiceInterface;
using Shop.Models.OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OpenWeatherController : Controller
    {
        private readonly IOpenWeatherServices _openWeatherServices;
        public OpenWeatherController
            (
                IOpenWeatherServices openWeatherServices
            )
        {
            _openWeatherServices = openWeatherServices;
        }

        [HttpGet]
        public IActionResult OpenSearchCity()
        {
            OpenSearchCity osc = new OpenSearchCity();

            return View(osc);
        }
        [HttpPost]
        public IActionResult OpenSearchCity(OpenSearchCity model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("OpenCity", "OpenWeather", new { city = model.OpenCityName });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult OpenCity(string city)
        {

            OpenWeatherResultDto dto = new OpenWeatherResultDto();

            dto.name = city;

            var weatherResponse = _openWeatherServices.OpenWeatherDetail(dto);

            OpenCityViewModel model = new OpenCityViewModel();

            model.name = weatherResponse.Result.name;
            model.main = weatherResponse.Result.main;
            model.temp = weatherResponse.Result.temp;
            model.feels_like = weatherResponse.Result.feels_like;
            model.pressure = weatherResponse.Result.pressure;
            model.humidity = weatherResponse.Result.humidity;

            model.speed = weatherResponse.Result.speed;

            return View(model);
        }
    }
}