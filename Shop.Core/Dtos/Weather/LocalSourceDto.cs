﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Core.Dtos.Weather
{
    public class LocalSourceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WeatherCode { get; set; }
    }
}
