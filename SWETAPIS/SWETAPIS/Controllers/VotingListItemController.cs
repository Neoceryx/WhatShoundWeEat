using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWETAPIS.Models;

namespace SWETAPIS.Controllers
{
    public class VotingListItemController : Controller
    {
        #region Variables
        VotingListItemRepository _vtliBLL = new VotingListItemRepository();
        #endregion

        [HttpPost]
        public int AddItemByVotingListId(String ITEMNAME, int VLISTID, String USERNAME) {
            return _vtliBLL.AddItemByVotingListId(ITEMNAME, VLISTID, USERNAME);
        }

        [HttpPost]
        public JsonResult GetItemsByVotingListId(int VLISTID) {
            return Json(_vtliBLL.GetItemsByVotingListId(VLISTID),JsonRequestBehavior.AllowGet);
        }


    }
}