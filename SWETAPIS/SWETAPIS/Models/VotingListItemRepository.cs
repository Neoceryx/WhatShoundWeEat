using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWETAPIS.Models
{    
    public class VotingListItemRepository
    {
        #region Variables
        // create context Object
        WSWETEntities _context = new WSWETEntities();
        UserRepository _usrBLL = new UserRepository();
        #endregion

        public int AddItemByVotingListId(String ITEMNAME, int VLISTID, String USERNAME) {

            // initialize the variable
            int Data = 0;

            // Handling Errors
            try
            {
                // get Id by UserName
                var UserId = _usrBLL.GetUserIdByUserName(USERNAME);

                // Validate the user is valid
                Data = UserId == 0 ? 00 : 0;

                // get the number of times the item appear on the list
                Data = _context.VotingListItems.Where(x => x.ItenName.Contains(ITEMNAME) && x.VotingList_Id == VLISTID).Count();
                
                // validate item is not add more tah 1 time
                if (Data == 0)
                {

                    #region RegisterNewItemOnVotationList
                    // create model object
                    VotingListItem _item = new VotingListItem();

                    // set new item values
                    _item.VotingList_Id = VLISTID;
                    _item.ItenName = ITEMNAME;
                    _item.Users_Id = UserId;

                    // save database changes
                    _context.VotingListItems.Add(_item);
                    _context.SaveChanges();
                    #endregion

                }
                // End item validation

            }
            catch (Exception ex)
            {
            }
            // Handling Errors

            // return 00 User is invalid, 0 Alld one, != 0 Itemis registered
            return Data;

        }
        // End function

        public List<VotingListItemViewModel> GetItemsByVotingListId(int VLISTID) {

            // Initialize the list
            List<VotingListItemViewModel> Items = new List<VotingListItemViewModel>();

            // Handling Errors
            try
            {
                // Build the Query, Get Item on the Votaing list and the number of votes that they have
                String Query = @"SELECT VotingListItems.Id, VotingList_Id, ItenName, Users.UserName,(select COUNT(*) from Votes where VotingListItems_Id =  VotingListItems.Id)[VotesCast]
                                FROM VotingListItems
                                INNER JOIN Users ON(VotingListItems.Users_Id = Users.Id)
                                WHERE VotingListItems.VotingList_Id = {1}
                                ORDER by VotesCast DESC";

                // Execute the Query
                Items = _context.Database.SqlQuery<VotingListItemViewModel>(Query, VLISTID).ToList();

            }
            catch (Exception ex)
            {
            }
            // Handling Errors

            return Items;

        }
        // End  


    }
}