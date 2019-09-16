using System;

namespace AirportTest.Entities.Models
{
    public class Airport
    {
        public Guid AirportId { get; set; }

        public string Country { get; set; }

        public string CityIata { get; set; }

        public string Iata { get; set; }

        public string City { get; set; }

        public string TimeZoneRegionName { get; set; }

        public string CountryIata { get; set; }

        public int Rating { get; set; }

        public string Name { get; set; }
        
        public EAirportType Type { get; set; }

        public int Hubs { get; set; }
    }
}
