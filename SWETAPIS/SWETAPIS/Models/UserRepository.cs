using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWETAPIS.Models
{
    public class UserRepository
    {
        #region Variables
        // create context Object
        WSWETEntities _context = new WSWETEntities();
        #endregion

        public User LoginUser(String USRNAME, String PASSWORD) {

            User _usr = new User();

            // Handling Errors
            try
            {
                // Get user if is Active
                _usr = _context.Users.Where(x => x.UserName == USRNAME && x.Password == PASSWORD && x.IsActive == true).FirstOrDefault();

            }
            catch (Exception ex)
            {

            }
            // Handling Errors

            return _usr;

        }

    }
}