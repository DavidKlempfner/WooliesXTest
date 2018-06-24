using System.Web.Mvc;
using WooliesXTest.Constants;

namespace WooliesXTest.Controllers
{
    public class UserController : Controller
    {
        // GET: Home
        public JsonResult Index()
        {
            var x = new { name = GenericConstants.Name, token = GenericConstants.Token };
            return Json(x, JsonRequestBehavior.AllowGet);
        }
    }
}