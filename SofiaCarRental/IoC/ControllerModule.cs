using Ninject.Modules;
using Ninject.Web.Common;
using SofiaCarRental.DAL;
using SofiaCarRental.Repositories;
using SofiaCarRental.Services;

namespace SofiaCarRental.InjectionPolicy
{
    public class ControllerModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ISofiaCarRentalContextUnitOfWork>().To<SofiaCarRentalContext>()
                    .InRequestScope()
                    .WithConstructorArgument( "connectionId", "SofiaCarRentalConnectionString" );

            this.Bind<ICarRepository>().To<CarRepository>()
                    .InRequestScope();

            this.Bind<IRentalOrderRepository>().To<RentalOrderRepository>()
                    .InRequestScope();

            this.Bind<IRentalRateRepository>().To<RentalRateRepository>()
                .InRequestScope();

            this.Bind<CarService>().To<CarService>()
                .InRequestScope();
        }
    }
}