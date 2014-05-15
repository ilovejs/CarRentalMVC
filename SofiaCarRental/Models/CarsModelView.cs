using System.Collections.Generic;
using SofiaCarRental.DAL;

namespace SofiaCarRental.Models
{
    public class CarsViewModel
    {
        public CarsViewModel()
        {
            this.Cars = new List<Car>();
            this.DatePickerModelView = new DatePickerModelView();
        }

        public IList<Car> Cars { get; set; }
        public DatePickerModelView DatePickerModelView { get; set; }
    }
}