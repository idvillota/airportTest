using AirportTest.Contracts.Logger;
using AirportTest.Contracts.Repository;
using AirportTest.Entities;
using AirportTest.Entities.Models;

namespace Airport.Repository
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(RepositoryContext repositoryContext, ILoggerManager logger)
            : base(repositoryContext, logger)
        {
        }
    }
}
