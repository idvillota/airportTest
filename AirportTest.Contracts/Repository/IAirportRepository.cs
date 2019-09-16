using AirportTest.Entities.ExtendedModels;
using AirportTest.Entities.Models;
using System;

namespace AirportTest.Contracts.Repository
{
    public interface IAirportRepository: IRepositoryBase<Airport>
    {
        AirportExtended GetAirportWithDetails(Guid airportId);

        AirportExtended GetAirportWithDetailsByIata(string iata);
    }
}
