using System;

namespace SofiaCarRental.Helpers
{
    public static class CarsSearchUtils
    {

        public static void ModifyDatesIfNecessary(ref DateTime? rentalPickUpDateTime, ref DateTime? rentalReturnDateTime)
        {
            if (rentalPickUpDateTime.HasValue && !rentalReturnDateTime.HasValue)
            {
                rentalReturnDateTime = rentalPickUpDateTime.Value.AddDays(1);
            }
            else if (!rentalPickUpDateTime.HasValue && rentalReturnDateTime.HasValue)
            {
                rentalPickUpDateTime = rentalReturnDateTime.Value.AddDays(-1);
            }
            else if (!rentalPickUpDateTime.HasValue && !rentalReturnDateTime.HasValue)
            {
                rentalPickUpDateTime = DateTime.Today;
                rentalReturnDateTime = rentalPickUpDateTime.Value.AddDays(1);
            }
        }
    }
}