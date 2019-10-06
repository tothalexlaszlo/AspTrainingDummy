using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Training.MvcFrontend.Validation;

namespace Training.MvcFrontend.Models
{
    public class CreateCategoryViewModel : IValidatableObject
    {
        [DisplayName("Category Name")] // Testreszabhatóak az egyes LabelFor kiírások
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [ContainsAlexAttribute(ErrorMessage ="Value must contain Alex")]
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CategoryName.Length+Description.Length>20)
            {
                return new List<ValidationResult> { new ValidationResult("Name and description cannot exceed 20 characters") };
            }

            return new List<ValidationResult> { ValidationResult.Success };
        }
    }
}