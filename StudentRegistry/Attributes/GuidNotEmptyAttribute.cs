using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRegistry.Attributes
{
    public class GuidNotEmptyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is Guid guid && guid == Guid.Empty)
            {
                return new ValidationResult("The GUID cannot be empty.");
            }
            return ValidationResult.Success;
        }
    }
}
