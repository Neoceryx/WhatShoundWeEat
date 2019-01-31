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
    public class VotesController : Controller
    {
        #region Variables
        VoteRepository _voteBll = new VoteRepository();
        #endregion

        [HttpPost]
        public int RegisterVoteByUserIdAndItemId(String USERNAME, int VLISTID, int ITEMID) {
            return _voteBll.RegisterVoteByUserIdAndItemId(USERNAME, VLISTID, ITEMID);
        }

    }
}