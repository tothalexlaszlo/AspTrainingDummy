using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training.MvcFrontend.Models
{
    public class CreateProductViewModel
    {
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        [UIHint("CategoryEditor")] //Ha valahol a Viewn belül EditorFor van meghíva akkor keresse meg ezt a szerkesztőnézetett a View/Shared/EditorTemplates/... mapában.
        public int CategoryID { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        public decimal UnitPrice { get; set; }

    }
}