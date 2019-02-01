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


    }
}