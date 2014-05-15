using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SofiaCarRental.DAL
{
    [DateTimeMustBeGreater( "RentEndDate", "RentStartDate", ErrorMessage = "The end date should be after the start date." )]
    [BookShouldBeLessThanMonth( "RentStartDate", "RentEndDate", ErrorMessage = "Booking for more than 30 days is not allowed." )]
    [MetadataType( typeof( RentalOrderMetadata ) )]
    public partial class RentalOrder
    {
        public virtual void CalculateAppliedRate( RentalRate rate )
        {
            double days = this.RentEndDate.Subtract(this.RentStartDate).TotalDays;
            
            if ( days < 7 )
            {
                this.RateApplied = rate.Daily;
            }
            else if ( days < 30.5 )
            {
                this.RateApplied = rate.Weekly;
            }
            else
            {
                this.RateApplied = rate.Monthly;
            }
        }

        public class RentalOrderMetadata
        {
            [Required]
            [DisplayName( "Start Date" )]
            [DataType( DataType.Date )]
            public DateTime? RentStartDate
            {
                get;
                set;
            }

            [Required]
            [DisplayName( "End Date" )]
            [DataType( DataType.Date )]
            public DateTime? RentEndDate
            {
                get;
                set;
            }

            [DisplayName( "All" )]
            public int? Days
            {
                get;
                set;
            }
        }
    }
}
