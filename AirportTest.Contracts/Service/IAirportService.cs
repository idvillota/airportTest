using AirportTest.Entities.ExtendedModels;
using AirportTest.Entities.Models;
using System;

namespace AirportTest.Contracts.Service
{
    public interface IAirportService: IEntityService<Airport>
    {
        AirportExtended GetAirportWithDetails(Guid airportId);

        AirportExtended GetAirportByIata(string iata);
    }
}
