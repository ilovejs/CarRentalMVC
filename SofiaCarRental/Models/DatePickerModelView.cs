using System;
using System.ComponentModel;
using SofiaCarRental.DAL;
using SofiaCarRental.Helpers;

namespace SofiaCarRental.Models
{
    [DateTimeMustBeGreater("RentalReturnDate", "RentalPickUpDate", ErrorMessage = "The end date should be after the start date.")]
    public class DatePickerModelView
    {
        private DateTime? rentalPickUpDateTime;

        [DisplayName("Date")]
        public DateTime? RentalPickUpDate
        {
            get
            {
                return this.rentalPickUpDateTime;
            }
            set
            {
                if (value.HasValue)
                {
                    var date = this.rentalPickUpDateTime ?? SystemTime.Now();
                    this.rentalPickUpDateTime = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, date.Hour, date.Minute, date.Second);
                }
            }
        }

        [DisplayName("Time")]
        public DateTime? RentalPickUpTime
        {
            get
            {
                return this.rentalPickUpDateTime;
            }
            set
            {
                if (value.HasValue)
                {
                    var date = this.rentalPickUpDateTime ?? SystemTime.Now();
                    this.rentalPickUpDateTime = new DateTime(date.Year, date.Month, date.Day, value.Value.Hour, value.Value.Minute, value.Value.Second);
                }
            }
        }

        private DateTime? rentalReturnDateTime;

        [DisplayName("Date")]
        public DateTime? RentalReturnDate
        {
            get
            {
                return this.rentalReturnDateTime;
            }
            set
            {
                if (value.HasValue)
                {
                    var date = this.rentalReturnDateTime ?? SystemTime.Now();
                    this.rentalReturnDateTime = new DateTime(value.Value.Year, value.Value.Month, value.Value.Day, date.Hour, date.Minute, date.Second);
                }
            }
        }

        [DisplayName("Time")]
        public DateTime? RentalReturnTime
        {
            get
            {
                return this.rentalReturnDateTime;
            }
            set
            {
                if (value.HasValue)
                {
                    var date = this.rentalReturnDateTime ?? SystemTime.Now();
                    this.rentalReturnDateTime = new DateTime(date.Year, date.Month, date.Day, value.Value.Hour, value.Value.Minute, value.Value.Second);
                }
            }
        }
    }
}