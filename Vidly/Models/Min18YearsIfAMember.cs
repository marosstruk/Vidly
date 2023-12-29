using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.NotSubscribed ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");

            float age = (DateOnly.FromDateTime(DateTime.Today).DayNumber - customer.Birthdate.Value.DayNumber) / 365;
            if (age >= 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("Customer must be at least 18 years old to go on a membership.");
        }
    }
}
