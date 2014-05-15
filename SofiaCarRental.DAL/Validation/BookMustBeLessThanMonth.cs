using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SofiaCarRental.DAL
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class BookShouldBeLessThanMonth : ValidationAttribute
    {
        private const int OneMonth = 31;
        private const string DefaultErrorMessage = "Booking for more than month is not allowed.";

        private readonly object typeId = new object();

        public BookShouldBeLessThanMonth(string originalProperty, string confirmProperty)
            : base(DefaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string OriginalProperty
        {
            get;
            private set;
        }

        public string ConfirmProperty
        {
            get;
            private set;
        }

        public override object TypeId
        {
            get
            {
                return typeId;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentUICulture, ErrorMessageString, OriginalProperty, ConfirmProperty);
        }

        public override bool IsValid(object value)
        {
            var properties = TypeDescriptor.GetProperties(value);

            DateTime startDate = (DateTime)properties.Find(OriginalProperty, true /* ignoreCase */).GetValue(value);
            DateTime endDate = (DateTime)properties.Find(ConfirmProperty, true /* ignoreCase */).GetValue(value);
            
            return (endDate - startDate).Days <= OneMonth;
        }
    }
}