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
            }
            else
            {
                List<Product> products = _productsService.GetSortedProducts(sortOption);
                return Json(products, JsonRequestBehavior.AllowGet);
            }                
        }
    }
}