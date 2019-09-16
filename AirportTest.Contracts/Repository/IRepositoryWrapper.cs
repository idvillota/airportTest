namespace AirportTest.Contracts.Repository
{
    public interface IRepositoryWrapper
    {
        IAirportRepository Airport { get; }
        ILocationRepository Location { get; }
        void Save();
    }
}
