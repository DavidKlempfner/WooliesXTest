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
            List<Product> products = _productsService.GetProducts(sortOption);
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}