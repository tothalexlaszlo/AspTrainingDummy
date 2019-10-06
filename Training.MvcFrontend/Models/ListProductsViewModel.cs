using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training.MvcFrontend.Models
{
    public class ListProductsViewModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
        public string CategoryName { get; set; }
    }
}