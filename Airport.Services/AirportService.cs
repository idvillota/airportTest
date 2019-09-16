using AirportTest.Contracts.Logger;
using AirportTest.Contracts.Repository;
using AirportTest.Contracts.Service;
using AirportTest.Entities.ExtendedModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Airport.Services
{
    public class AirportService : BaseService, IAirportService
    {
        public AirportService(IRepositoryWrapper repositoryWrapper, ILoggerManager logger)
            :base(repositoryWrapper, logger)
        {
        }

        public void Create(AirportTest.Entities.Models.Airport airport)
        {
            try
            {
                _repositoryWrapper.Airport.Create(airport);
                _repositoryWrapper.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"AirportService::Create::{ex.Message}");
                throw;
            }
        }

        public void Delete(AirportTest.Entities.Models.Airport airport)
        {
            try
            {
                _repositoryWrapper.Airport.Delete(airport);
                _repositoryWrapper.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError($"AirportService::Delete::{ex.Message}");
                throw;
            }
        }

        public IList<AirportTest.Entities.Models.Airport> GetAll()
        {
            try
            {
                return _repositoryWrapper.Airport.GetAll().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"AirportService::GetAll::{ex.Message}");
                throw;
            }
        }

        public AirportExtended GetAirportWithDetails(Guid airportId)
        {
            try
            {
                return _repositoryWrapper.Airport.GetAirportWithDetails(airportId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AirportService::GetAirportWithDetails::{ex.Message}");
                throw;
            }
        }

        public AirportExtended GetAirportByIata(string iata)
        {
            try
            {
                return _repositoryWrapper.Airport.GetAirportWithDetailsByIata(iata);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AirportService::GetAirportByIata::{ex.Message}");
                throw new Exception($"AirportService::GetAirportByIata", ex);
            }
        }

        public AirportTest.Entities.Models.Airport GetById(Guid airportId)
        {
            try
            {
                return _repositoryWrapper.Airport.GetById(airportId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AirportService::GetById::{ex.Message}");
                throw;
            }
        }

        public void Update(AirportTest.Entities.Models.Airport airport)
        {
            try
            {
                _repositoryWrapper.Airport.Update(airport);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AirportService::Update::{ex.Message}");
                throw;
            }
        }
    }
}
