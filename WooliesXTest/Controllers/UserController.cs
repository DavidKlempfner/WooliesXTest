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
            var x = new { name = "David Klempfner", token = "0880a9fd-0906-4b17-ba88-88750753a165" };
            return Json(x, JsonRequestBehavior.AllowGet);
        }
    }
}