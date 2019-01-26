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
    public class GroupController : Controller
    {
        #region Variables
        GroupRepository _gpBLL = new GroupRepository();
        #endregion

        [HttpPost]
        public String RegisterNewGroup(String GROUPNAME, String USERNAME) {

            return _gpBLL.RegisterNewGroup(GROUPNAME, USERNAME);

        }
        // End method

        [HttpPost]
        public JsonResult GetActivesGroupsByUserId(String USERNAME) {
            return Json(_gpBLL.GetActivesGroupsByUserId(USERNAME), JsonRequestBehavior.AllowGet);
        }

    }
}