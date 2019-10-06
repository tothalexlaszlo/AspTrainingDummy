using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training.RestInterface.Models
{
    public class CreateCategoryDto
    {
        [Required]
        public string CategoryName { get; set; }

        public string Discription { get; set; }
    }
}