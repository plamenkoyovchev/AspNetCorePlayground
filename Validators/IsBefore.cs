using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AspNetCorePlayground.Validators
{
    public class IsBefore : ValidationAttribute
    {
        private const string DateFormat = "dd/MM/yyyy";
        private readonly DateTime date;

        public IsBefore(string before)
        {
            this.date = DateTime.ParseExact(before, DateFormat, CultureInfo.InvariantCulture);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue && dateValue >= this.date)
            {
                return new ValidationResult(this.ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}