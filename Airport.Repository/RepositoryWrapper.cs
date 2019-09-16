using AirportTest.Contracts.Logger;
using AirportTest.Contracts.Repository;
using AirportTest.Entities;

namespace Airport.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private IAirportRepository _airportRepository;
        private ILocationRepository _locationRepository;
        private ILoggerManager _logger;

        public IAirportRepository Airport
        {
            get
            {
                _airportRepository = _airportRepository == null ? new AirportRepository(_repositoryContext, _logger) : _airportRepository;

                return _airportRepository;
            }
        }

        public ILocationRepository Location
        {
            get
            {
                _locationRepository = _locationRepository == null ? new LocationRepository(_repositoryContext, _logger) : _locationRepository;
                return _locationRepository;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext, ILoggerManager logger)
        {
            _logger = logger;
            _repositoryContext = repositoryContext;
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
