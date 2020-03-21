﻿using System;

namespace WeatherMonitor.Core.Entities
{
    public class City: BaseEntity
    {
        public string Name { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    
    }
}
