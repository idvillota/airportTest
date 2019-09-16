using System;

namespace AirportTest.Entities.Models
{
    public class Location
    {           
        public Guid LocationId { get; set; }

        public string Lon { get; set; }

        public string Lat { get; set; }

        public Guid AirportId { get; set; }

        public Airport Airport { get; set; }        
    }
}