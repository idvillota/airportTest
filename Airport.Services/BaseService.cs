using AirportTest.Contracts.Logger;
using AirportTest.Contracts.Repository;

namespace Airport.Services
{
    public class BaseService
    {
        internal ILoggerManager _logger;
        internal IRepositoryWrapper _repositoryWrapper;

        public BaseService(IRepositoryWrapper repositoryWrapper, ILoggerManager logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }
    }
}
