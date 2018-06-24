using System.Collections.Generic;
using System.Web.Mvc;
using WooliesXTest.Abstract;
using WooliesXTest.Enums;
using WooliesXTest.Models;

namespace WooliesXTest.Controllers
{
    public class SortController : Controller
    {
        IProductsService _productsService;
        public SortController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public JsonResult Index(SortOptions sortOption = SortOptions.Low)
        {
            if (sortOption == SortOptions.Recommended)
            {
                List<RecommendedProducts> recommendedProducts = _productsService.GetRecommendedProducts();
                return Json(recommendedProducts, JsonRequestBehavior.AllowGet);
                //I wasn't sure what was expected for this.
                //Requirement says "needs to return based on popularity" and "same data structure as the 'products' response".
                //I added the quantities for each product from each customer to get the total quantity, to then determine the popularity, however this failed:
                //"[{\"name\":\"Test Product C\",\"price\":10.99,\"quantity\":3.0},{\"name\":\"Test Product F\",\"price\":999999999999.0,\"quantity\":4.0},{\"name\":\"Test Product B\",\"price\":101.99,\"quantity\":5.0},{\"name\":\"Test Product A\",\"price\":99.99,\"quantity\":6.0}]";
            }
            else
            {
                List<Product> products = _productsService.GetSortedProducts(sortOption);
                return Json(products, JsonRequestBehavior.AllowGet);
            }
        }
    }
}