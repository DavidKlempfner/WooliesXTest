using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WooliesXTest.Enums;
using WooliesXTest.Models;

namespace WooliesXTest.Abstract
{
    public interface IProductsSorter
    {
        List<Product> SortProducts(List<Product> products, SortOptions sortOption);
    }
}
