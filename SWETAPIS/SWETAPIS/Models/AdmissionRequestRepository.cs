using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWETAPIS.Models
{
    public class AdmissionRequestRepository
    {

        #region Variables
        // Create context Object
        WSWETEntities _context = new WSWETEntities();
        UserRepository _usrBLL = new UserRepository();
        #endregion

        public int SendAddmissionRequest(String USERNAME, int GROUPID) {

            // initialize the variable
            int data = 0;

            // Handling Errors
            try
            {
                var UserId = _usrBLL.GetUserIdByUserName(USERNAME);

                // get the number of Admission request sended from user to a group
                data = _context.AdmissionRequests.Where(x => x.Users_Id == UserId && x.Groups_Id == GROUPID).Count();

                // validate if the user all ready send a request to join a group
                if (data == 0)
                {
                    #region RegisterNewAdmissionRequest
                    // create object from the model
                    AdmissionRequest _req = new AdmissionRequest();

                    // set Request values
                    _req.Groups_Id = GROUPID;
                    _req.Users_Id = UserId;
                    _req.StatusRequest_Id = 1;

                    // save database Changes
                    _context.AdmissionRequests.Add(_req);
                    _context.SaveChanges();
                    #endregion
                }
                // End Request validation

            }
            catch (Exception ex)
            {
            }
            // Handling Errors

            // retrun 0 as new request added / return 1 as aallready request send to the sema user and to the group
            return data;

        }
        // End Function

        public int GetAdmissionRequestByGroupId(int GROUPID) {

            // initialize the variable
            int RequestQty = 0;

            // Handling Errors
            try
            {
                // get the number of new Request Recibed by groupid
                RequestQty = _context.AdmissionRequests.Where(x => x.Groups_Id == GROUPID && x.StatusRequest_Id == 1).Count();

            }
            catch (Exception ex)
            {

            }
            // Handling Errors

            return RequestQty;

        }
        // End Function

        public List<AdmissionRequestViewModel> GetAllAdmisisonRequestByGroupId(int GROUPID) {

            // Initialize Request List
            List<AdmissionRequestViewModel> Requests = new List<AdmissionRequestViewModel>();

            // Handling Errors
            try
            {

                String Query = @"select AdmissionRequests.Id, Users_Id, Users.UserName, StatusRequest_Id FROM AdmissionRequests
                                INNER JOIN Users ON (AdmissionRequests.Users_Id = Users.Id)
                                where Groups_Id = {0} AND StatusRequest_Id IN (1,2)
                                ORDER BY StatusRequest_Id";

                // Execute the query
                Requests = _context.Database.SqlQuery<AdmissionRequestViewModel>(Query, GROUPID).ToList();

            }
            catch (Exception ex)
            {

            }
            // Handling Errors

            return Requests;

        }

    }
}