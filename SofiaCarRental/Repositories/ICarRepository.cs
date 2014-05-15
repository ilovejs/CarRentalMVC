using SofiaCarRental.DAL;

namespace SofiaCarRental.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        Car Find(int id);
    }
}
