using System.ComponentModel.DataAnnotations;
using SkyFlix.Models;

namespace SkyFlix.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success!;

            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success!
                        : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}
