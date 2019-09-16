using System;
using System.Linq;
using AirportTest.Contracts.Logger;
using AirportTest.Contracts.Repository;
using AirportTest.Entities;
using AirportTest.Entities.ExtendedModels;

namespace Airport.Repository
{
    public class AirportRepository: RepositoryBase<AirportTest.Entities.Models.Airport>, IAirportRepository
    {
        public AirportRepository(RepositoryContext repositoryContext, ILoggerManager logger)
            :base(repositoryContext, logger)
        {
        }

        public AirportExtended GetAirportWithDetails(Guid airportId)
        {   
            var airport = GetById(airportId);
            var airportExtended = new AirportExtended(airport);
            airportExtended.Location = RepositoryContext.Locations
                .First(l => l.AirportId == airportId);

            return airportExtended;
        }

        public AirportExtended GetAirportWithDetailsByIata(string iata)
        {
            try
            {
                var airport = RepositoryContext.Airports.FirstOrDefault(a => a.Iata == iata.ToUpper());
                return GetAirportWithDetails(airport.AirportId);
            }
            catch(NullReferenceException)
            {
                _logger.LogError($"AirportRepository::GetAirportWithDetails::The aren't an aiport with iata={iata}");
                throw new NullReferenceException($"AirportRepository::GetAirportWithDetails::The aren't an aiport with iata={iata}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"AirportRepository::GetAirportWithDetails::{ex.Message}");
                throw new Exception($"AirportRepository::GetAirportWithDetails::{ex.Message}");
            }

        }
    }
}
