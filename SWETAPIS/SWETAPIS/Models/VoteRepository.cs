using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWETAPIS.Models
{
    public class VoteRepository
    {
        #region Variables
        // Create context Object
        WSWETEntities _context = new WSWETEntities();

        UserRepository _usrBll = new UserRepository();
        #endregion

        public int RegisterVoteByUserIdAndItemId(String USERNAME, int VLISTID, int ITEMID) {

            // Initialize the variable
            int HasVote = 0;

            // Handling Errors
            try
            {
                // Recover UserId by UserName
                var UserId = _usrBll.GetUserIdByUserName(USERNAME);

                // Create the Query to get the Numver of votes form a user by VotationList
                String Query = @"SELECT Votes.Id, VotingListItems_Id, Votes.Users_Id FROM Votes
                                INNER JOIN VotingListItems ON(Votes.VotingListItems_Id = VotingListItems.Id)
                                WHERE Votes.Users_Id = {0} AND VotingListItems.VotingList_Id = {1}";

                // Executhe the query
                var vote = _context.Votes.SqlQuery(Query, UserId, VLISTID).FirstOrDefault();

                // get the number of votes 
                HasVote = vote == null ? 0 : 1; 
                
                // validate if the user allready voted on a voting listId
                if (HasVote == 0)
                {
                    #region RegisterVote
                    // create Vote Model Object
                    Vote _vote = new Vote();

                    // set new vote Value
                    _vote.VotingListItems_Id = ITEMID;
                    _vote.Users_Id = UserId;

                    // Save database Changes
                    _context.Votes.Add(_vote);
                    _context.SaveChanges();
                    #endregion

                }
                else
                {

                    #region ChangeUserVote
                    // Change the Item Id
                    vote.VotingListItems_Id = ITEMID;

                    // Save DataBase changes
                    _context.SaveChanges();
                    #endregion

                }
                // End Use Votes Validations 

            }
            catch (Exception ex)
            {
            }
            // Handling Errors

            return HasVote;

        }


    }
}