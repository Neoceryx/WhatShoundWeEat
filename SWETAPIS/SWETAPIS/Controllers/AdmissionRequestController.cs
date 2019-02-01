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
    public class AdmissionRequestController : Controller
    {
        #region Variables
        AdmissionRequestRepository _adRequestBll = new AdmissionRequestRepository();        
        #endregion

        [HttpPost]
        public int NewAdmissionRequestByUserAndGroupId(String USERNAME, int GROUPID)
        {
            return _adRequestBll.SendAddmissionRequest(USERNAME, GROUPID);
        }

        [HttpPost]
        public int GetAdmissionRequestByGroupId(int GROUPID) {
            return _adRequestBll.GetAdmissionRequestByGroupId(GROUPID);
        }

        [HttpPost]
        public JsonResult GetAllAdmissionRequestByGroupId(int GROUPID) {
            return Json(_adRequestBll.GetAllAdmisisonRequestByGroupId(GROUPID), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void ChangeRequestStatusByRequestId(int REQUESTID, int STATUS) {
            _adRequestBll.ChangeRequestStatusById(REQUESTID, STATUS);
     
        }

    }
}