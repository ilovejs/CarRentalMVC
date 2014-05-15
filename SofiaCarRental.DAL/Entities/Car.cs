using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SofiaCarRental.DAL
{
    [MetadataType( typeof( CarMetadata ) )]
    public partial class Car
    {
        public class CarMetadata
        {
            [DisplayName( "Manufacturer" )]
            public string Make
            {
                get;
                set;
            }

            [DisplayName( "Model" )]
            public string Model
            {
                get;
                set;
            }

            [DisplayName( "Year" )]
            public short? CarYear
            {
                get;
                set;
            }
        }

        public bool IsAvailable(DateTime pickUpDate, DateTime returnDate)
        {
            return
               this.RentalOrders.Count == 0 ||
               (this.RentalOrders.Any(o => (returnDate >= o.RentStartDate && pickUpDate <= o.RentEndDate)) == false);
        }
    }
}
