using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWETAPIS.Models
{
    public class GroupRepository
    {
        #region Variables
        // create context Object
        WSWETEntities _context = new WSWETEntities();

        UserRepository _userBLL = new UserRepository();
        #endregion

        public GroupRepository() {
            _context.Configuration.ProxyCreationEnabled = false;
        }

        public String RegisterNewGroup(String GROUPNAME, String USERNAME) {
            
            String IsValid = "0";

            // Handling Errors
            try
            {
                // Validate if the Username still valid
                if (_userBLL.ValidateUserByNickName(USERNAME))
                {
                    // get userId assosiated by UserName
                    var UserId = _userBLL.GetUserIdByUserName(USERNAME);
                    
                    // get the new of times the group name appears by userid
                    int IsGroupValid = _context.Groups.Where(x => x.GroupName.Contains(GROUPNAME)).Count();

                    // validate that the user does not have another group whit the same name
                    if (IsGroupValid >= 1)
                    {
                        // Set 2 as GroupName Duplicated
                        IsValid = "2";
                    }
                    else
                    {
                        #region RegisterNewGroup
                        //crea group model Object
                        Group _gp = new Group();

                        // set new Group values
                        _gp.GroupName = GROUPNAME;
                        _gp.Users_Id = UserId;
                        _gp.IsAdmin = true;
                        _gp.IsActive = true;
                        _gp.CreatedDate = DateTime.Now;

                        // Save Database changes
                        _context.Groups.Add(_gp);
                        _context.SaveChanges();

                        // Recover the id from the group created
                        int GroupId = _gp.Id;

                        // Set 0 as RegisterOperation sucessful
                        IsValid = "0:" + GroupId.ToString();
                        #endregion
                    }
                    // End Group name validation
                
                }else {

                    // set 1 as User invalid
                    IsValid = "1";

                }
                // End UserName validaiton

            }
            catch (Exception ex)
            {               
            
            }
            // Handling Errors

            return IsValid;

        }
        // End Method

    }
}