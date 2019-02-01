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
    public class GroupMembersController : Controller
    {
        #region Variables
        GroupMembersRepository _gmBLL = new GroupMembersRepository();
        #endregion

        [HttpPost]
        public int RegisterMemberByGroupId(int USERID, int GROUPID) {
            return _gmBLL.RegisterMembersByGroupId(USERID, GROUPID);
        }

    }
}