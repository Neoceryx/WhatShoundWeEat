using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWETAPIS.Models
{
    public class GroupMembersRepository
    {
        #region Variables
        // create context object
        WSWETEntities _context = new WSWETEntities();
        #endregion

        public int RegisterMembersByGroupId(int USERID, int GROUPID) {

            // initialize the variable
            int isMember = 0;

            // Handling Errors
            try
            {
                // check how many times a user appears in a group
                isMember = _context.GroupMembers.Where(x => x.Users_Id == USERID && x.Groups_Id == GROUPID).Count();

                // validate if the User is member from a group
                if (isMember == 0)
                {
                    #region RegisternewMemeber
                    // create the object for Gropup Member model
                    GroupMember _mbr = new GroupMember();

                    //set member values
                    _mbr.Groups_Id = GROUPID;
                    _mbr.Users_Id = USERID;
                    _mbr.RegisterDate = DateTime.Now;

                    // Save database Changes
                    _context.GroupMembers.Add(_mbr);
                    _context.SaveChanges();
                    #endregion
                }

            }
            catch (Exception)
            {
            }
            // Handling Errors

            // Retrun 0 as new member register != 0 as member registered
            return isMember;

        }


    }
}