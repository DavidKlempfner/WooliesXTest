using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WooliesXTest.Models
{
    public class RecommendedProducts
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}