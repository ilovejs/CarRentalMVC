using SofiaCarRental.DAL;

namespace SofiaCarRental.Repositories
{
    public interface IRentalRateRepository : IRepository<RentalRate>
    {
        RentalRate Find(int id);
    }
}