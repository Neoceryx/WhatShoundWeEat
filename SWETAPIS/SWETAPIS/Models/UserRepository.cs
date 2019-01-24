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

        public UserRepository() {
            _context.Configuration.ProxyCreationEnabled = false;
        }

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

        public int RegisterNewUser(String PNAME, String SNAME, String USRNAME, String PASS, String EMAIL, String GENDER) {

            // initilaize the variable
            int Response = 0;

            // Handling Errors
            try
            {
                // validate if the nickname allready is used
                if (ValidateUserByNickName(USRNAME))
                {
                    // set 1 as Nickname duplicated
                    Response = 1;
                }
                else
                {
                    // get the user by email
                    var IsRegister = _context.Users.Where(x => x.Email.Contains(EMAIL)).FirstOrDefault();

                    if (IsRegister != null)
                    {
                        // set 2 as a Email Duplicated
                        Response = 2;
                    }
                    else
                    {
                        #region RegisterNewUser

                        // create user model 
                        User _usr = new User();

                        //set new user values
                        _usr.PersonalName = PNAME;
                        _usr.Surnames = SNAME;
                        _usr.Gender = GENDER;
                        _usr.UserName = USRNAME;
                        _usr.Email = EMAIL;
                        _usr.Password = PASS;
                        _usr.ProfilePicture = null;
                        _usr.IsActive = true;
                        _usr.RegisterDate = DateTime.Now;

                        // Save DataBaseChanges 
                        _context.Users.Add(_usr);
                        _context.SaveChanges();

                        // set 0 as User Registered successful
                        Response = 0;

                        #endregion
                    }

                }
                // End nickname validation
                
            }
            catch (Exception ex)
            {
                
            }
            // Handling Errors

            return Response;

        }
        // End function

        public bool ValidateUserByNickName(String USERNAME) {

            bool IsUsed = false;

            // Handling Errors
            try
            {
                // Get the user by NickName
                var UserNameIsUsed = _context.Users.Where(x => x.UserName == USERNAME).Count();

                // validate if the nickname allready is used
                IsUsed = UserNameIsUsed >= 1 ? true : false;

            }
            catch (Exception ex)
            {
                
            }
            // End Handling Errors

            return IsUsed;
           
        }
        // End function

        public int GetUserIdByUserName(String USERNAME){

            int UserId = 0;

            // Handling Errors
            try
            {
                // Get the User Id By UserName. Id not exits, will return 0
                 UserId = _context.Users.Where(x => x.UserName == USERNAME && x.IsActive == true).Select(u => u.Id).FirstOrDefault();
                                 
            }
            catch (Exception ex)
            {                
            }
            // Handling Errors

            return UserId;

        }
        // End Method


    }
}