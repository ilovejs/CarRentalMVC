using System.Linq;
using SofiaCarRental.DAL;

namespace SofiaCarRental.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository( ISofiaCarRentalContextUnitOfWork context ) 
            : base(context)
        {
        }

        public Car Find(int id)
        {
            return this.Context.GetAll<Car>().FirstOrDefault(x => x.CarID == id);
        }
    }
}