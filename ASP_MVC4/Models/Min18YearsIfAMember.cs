using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_MVC4.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == MembershipType.Unknow
                || customer.MemberShipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthday == null)
                return new ValidationResult("Birthdate is required!");

            var age = DateTime.Now.Year - customer.Birthday.Value.Year;

            if (age >= 18)
                return ValidationResult.Success;
            else
                return new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}