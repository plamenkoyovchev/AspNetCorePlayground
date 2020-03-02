using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCorePlayground.Models
{
    public class InstallationViewModel : IValidatableObject
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime DateCreated { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult("Name is required");
            }

            if (string.IsNullOrWhiteSpace(Address))
            {
                yield return new ValidationResult("Address is required");
            }
        }
    }
}