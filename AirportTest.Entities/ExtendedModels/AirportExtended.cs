using AirportTest.Entities.Models;
using System;

namespace AirportTest.Entities.ExtendedModels
{
    public class AirportExtended
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

        public Location Location { get; set; }

        public EAirportType Type { get; set; }

        public int Hubs { get; set; }

        public AirportExtended()
        {
        }

        public AirportExtended(Airport airport)
        {
            AirportId = airport.AirportId;
            Country = airport.Country;
            CityIata = airport.CityIata;
            Iata = airport.Iata;
            City = airport.City;
            TimeZoneRegionName = airport.TimeZoneRegionName;
            CountryIata = airport.CountryIata;
            Rating = airport.Rating;
            Name = airport.Name;
            Type = airport.Type;
            Hubs = airport.Hubs;
        }
    }
}
