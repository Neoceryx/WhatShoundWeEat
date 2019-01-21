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

        public User LoginUser(String EMAIL, String PASSWORD) {

            User _usr = new User();

            // Handling Errors
            try
            {
                _usr = _context.Users.Where(x => x.Email == EMAIL && x.Password == PASSWORD).FirstOrDefault();

            }
            catch (Exception ex)
            {

            }
            // Handling Errors

            return _usr;

        }

    }
}