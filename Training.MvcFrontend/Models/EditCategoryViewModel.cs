using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.MvcFrontend.Models
{
    public class EditCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}