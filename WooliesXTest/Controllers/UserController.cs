using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WooliesXTest.Controllers
{
    public class UserController : Controller
    {
        // GET: Home
        public JsonResult Index()
        {
            var x = new { name = "test", token = "1234-455662-22233333-3333" };
            return Json(x, JsonRequestBehavior.AllowGet);
        }
    }
}