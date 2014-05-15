using System;
using System.Web.Mvc;
using SofiaCarRental.DAL;
using SofiaCarRental.Models;
using SofiaCarRental.Services;

namespace SofiaCarRental.Controllers
{
    public class CarController : Controller
    {
        public CarService carService;
        private readonly OrderService orderService;

        public CarController(CarService carService, OrderService orderService)
        {
            this.carService = carService;
            this.orderService = orderService;
        }

        public ActionResult Index()
        {
            return View(this.carService.GetAll());
        }

        public ActionResult Search(CarsViewModel model)
        {
            return View("Index", this.carService.Find(model));
        }

        public ActionResult SearchToday()
        {
            return View("Index", this.carService.FindToday());
        }

        public ActionResult Details(int? carId)
        {
            CarDetailViewModel viewModel = this.carService.Details(carId);
            if(viewModel == null)
            {
                return View("NotFound");
            }

            return View("Details", viewModel);
        }

        [HttpPost]
        public ActionResult CreateOrder(DateTime? newRentStartDate, DateTime? newRentEndDate, int carId)
        {
            RentalOrder order = new RentalOrder()
            {
                CarID = carId,
                RentStartDate = newRentStartDate ?? DateTime.Now,
                RentEndDate = newRentEndDate ?? DateTime.Now
            };

            if (this.TryValidateModel(order))
            {
                if (this.orderService.ExistRentalOrder(order))
                {
                    this.ModelState.AddModelError("Order", "The car is already booked for this period!");
                }
                else
                {
                    if (!this.orderService.AddRentalOrder(order))
                    {
                        this.ModelState.AddModelError("Order", "There was a problem while booking the car!");
                    }
                }
            }

            this.ViewData["sentForEdit"] = true;

            return this.Details(order.CarID);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditOrder(RentalOrder order, int? carId)
        {
            if (this.ModelState.IsValid)
            {
                if (!this.orderService.EditOrder(order))
                {
                    ModelState.AddModelError("Order", string.Format("Order with id = '{0}' was not found.", order.RentalOrderID));
                    return this.Details(carId);        
                }
            }
            else
            {
                return this.Details( carId );
            }

            return this.RedirectToAction("Details", "Car", new { carId = order.CarID });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteOrder(int id, int? carId)
        {
            if (!this.orderService.DeleteOrder(id))
            {
                ModelState.AddModelError("Order", string.Format("Order with id = '{0}' was not found.", id));
            };

            return RedirectToAction("Details", new { carId = carId });
        }
    }
}