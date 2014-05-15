using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common;

namespace SofiaCarRental
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {
        public static void RegisterRoutes( RouteCollection routes )
        {
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );
            routes.IgnoreRoute( "{*favicon}", new
            {
                favicon = @"(.*/)?favicon.ico(/.*)?"
            } );

            routes.MapRoute(
                null,
                "{controller}/{action}/{carId}",
                new
                {
                    controller = "RentalOrder",
                    action = "Create"
                },
                new
                {
                    controller = "RentalOrder",
                    action = "Create"
                } );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new
                {
                    controller = "Car",
                    action = "Index",
                    id = UrlParameter.Optional
                } // Parameter defaults
            );

        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            GlobalFilters.Filters.Add(new ValidateInputAttribute(false));
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes( RouteTable.Routes );
        }

        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load( Assembly.GetExecutingAssembly() );

            return kernel;
        }
    }
}