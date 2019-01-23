using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http.Cors; // To Allow Use Access-Control-Allow-Origin
using SWETAPIS.Models;

namespace SWETAPIS.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : Controller
    {
        #region Variables
        UserRepository _usrBll = new UserRepository();
        #endregion

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
        public JsonResult LoginUser(String USRNAME, String PASSWORD) {

            return Json(_usrBll.LoginUser(USRNAME, PASSWORD),JsonRequestBehavior.AllowGet);

        }
        // End Function

        [HttpPost]
        public JsonResult RegisterUser(String PNAME, String SNAME, String USRNAME, String PASS, String EMAIL, String GENDER)
        {
            var Data = _usrBll.RegisterNewUser(PNAME, SNAME, USRNAME, PASS, EMAIL, GENDER);
            
            return Json(Data, JsonRequestBehavior.AllowGet);

        }


    }
}