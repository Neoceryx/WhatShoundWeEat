using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWETAPIS.Models;

namespace SWETAPIS.Controllers
{
    public class VotingListController : Controller
    {
        #region Variables
        VotinglistRepository _vlBLL = new VotinglistRepository();
        #endregion

        [HttpPost]
        public int RegisertVotingListByGroupId(int GROUPID, String VLNAME, Nullable<DateTime> SHDEULEDATE) {
            return _vlBLL.RegisterVotingListByGroupId(GROUPID, VLNAME, SHDEULEDATE);

        }

        [HttpGet]
        public JsonResult GetVotationListActivesByGroupId(int GROUPID) {
           return Json(_vlBLL.GetVotationListactivesByGroupId(GROUPID), JsonRequestBehavior.AllowGet);
        }

    }
}