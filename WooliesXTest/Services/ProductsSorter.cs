using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WooliesXTest.Abstract;
using WooliesXTest.Enums;
using WooliesXTest.Models;

namespace WooliesXTest.Services
{
    public class ProductsSorter : IProductsSorter
    {
        public List<Product> SortProducts(List<Product> products, SortOptions sortOption)
        {
            switch (sortOption)
            {
                case SortOptions.Low:
                    return products.OrderBy(x => x.Price).ToList();
                case SortOptions.High:
                    return products.OrderByDescending(x => x.Price).ToList();
                case SortOptions.Ascending:
                    return products.OrderBy(x => x.Name).ToList();
                case SortOptions.Descending:
                    return products.OrderByDescending(x => x.Name).ToList();
                case SortOptions.Recommended:
                    //Move recommended logic here once this requirement is understood.
                    break;
                default:
                    throw new Exception("Need to update switch statement.");
            }

            return products;
        }
    }
}