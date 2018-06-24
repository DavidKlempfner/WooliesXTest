using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WooliesXTest.Controllers
{
    public class TrolleyCalculatorController : Controller
    {
        // GET: TrolleyCalculator
        public JsonResult Index()
        {
            //I couldn't understand the requirement for exercise 3.
            //The json body in the example was confusing.
            //It would have been easier to understand if there was an example of an input and what the expected output should be.
            return Json(null);
        }
    }
}