using System.Collections.Generic;
using WooliesXTest.Enums;
using WooliesXTest.Models;

namespace WooliesXTest.Abstract
{
    public interface IProductsService
    {
        List<Product> GetProducts(SortOptions sortOption);        
    }
}
