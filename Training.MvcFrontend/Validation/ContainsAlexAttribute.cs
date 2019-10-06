using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training.MvcFrontend.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ContainsAlexAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var stringValue = value as string;

            if(stringValue==null)
                return new ValidationResult("Value must be string");

            if (stringValue.Contains("Alex"))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage ?? "String does not contain Alex");
        }
    }
}