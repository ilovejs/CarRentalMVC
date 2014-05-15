using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SofiaCarRental.DAL
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class DateTimeMustBeGreater : ValidationAttribute
    {
        private const string defaultErrorMessage = "'{0}' is not greater than'{1}' .";

        private readonly object typeId = new object();

        public DateTimeMustBeGreater(string originalProperty, string confirmProperty)
            : base(defaultErrorMessage)
        {
            OriginalProperty = originalProperty;
            ConfirmProperty = confirmProperty;
        }

        public string ConfirmProperty
        {
            get;
            private set;
        }

        public string OriginalProperty
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

            DateTime? originalValue = (DateTime?)properties.Find(OriginalProperty, true /* ignoreCase */).GetValue(value);
            DateTime? confirmValue = (DateTime?)properties.Find(ConfirmProperty, true /* ignoreCase */).GetValue(value);

            if (!originalValue.HasValue || !confirmValue.HasValue)
            {
                return true;
            }

            return originalValue > confirmValue;
        }

    }
}