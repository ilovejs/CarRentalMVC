using System.Linq;
using SofiaCarRental.DAL;

namespace SofiaCarRental.Repositories
{
    public class RentalRateRepository : Repository<RentalRate>, IRentalRateRepository
    {

        public RentalRateRepository( ISofiaCarRentalContextUnitOfWork context ) 
            : base(context)
        {

        }

        public RentalRate Find(int id)
        {
            return this.Context.GetAll<RentalRate>().FirstOrDefault(x => x.RentalRateID == id);
        }
    }
}