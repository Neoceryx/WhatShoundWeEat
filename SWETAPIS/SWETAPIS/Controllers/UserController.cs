using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWETAPIS.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Test() {
            return Json("Server Is OK.......",JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult LoginUser(String EMAIL, String PASSWORD) {

            return Json("aaaa");

        }
        // End Function


    }
}