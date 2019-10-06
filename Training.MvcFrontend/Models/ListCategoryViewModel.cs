using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training.MvcFrontend.Models
{
    public class ListCategoryViewModel
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        [UIHint("CategoryImage")]
        public string Image { get; set; }
    }
}