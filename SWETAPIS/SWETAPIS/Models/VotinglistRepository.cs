using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWETAPIS.Models
{
    public class VotinglistRepository
    {
        #region Variables
        // create context Object
        WSWETEntities _context = new WSWETEntities();
        #endregion

        public int RegisterVotingListByGroupId(int GROUPID, String VLNAME, Nullable<DateTime> SHDEULEDATE)
        {

            int Data = 0;

            // Handling Errors
            try
            {
                // Count the number of times the voting list appear on a group
                Data = _context.VotingLists.Where(x => x.Groups_Id == GROUPID && x.ListName.Contains(VLNAME)).Count();

                // validate if the Voting lista is on a group
                if (Data == 0)
                {

                    #region RegisterNewVotingList

                    // create voting list model object
                    VotingList _vt = new VotingList();

                    //set the values for the new voting list
                    _vt.Groups_Id = GROUPID;
                    _vt.ListName = VLNAME;
                    _vt.ScheduledDate = SHDEULEDATE;
                    _vt.IsActive = true;
                    _vt.CreatedDate = DateTime.Now;

                    // save DataBase changes
                    _context.VotingLists.Add(_vt);
                    _context.SaveChanges();

                    #endregion

                }

            }
            catch (Exception ex)
            {
            }
            // Handling Errors

            // return 0 if all is done, else retrun a number
            return Data;

        }

        public List<VotationListViewModel> GetVotationListactivesByGroupId(int GROUPID)
        {

            // Initialize the list
            List<VotationListViewModel> VotationList = new List<VotationListViewModel>();

            // Handling Errors
            try
            {
                // Build the Query. to get the Votations list actives and the number of  votes casted
                var Query = @"SELECT VotingList.Id, ListName, ScheduledDate, CreatedDate
                ,(SELECT COUNT(*) FROM Votes INNER JOIN VotingListItems ON (Votes.VotingListItems_Id = VotingListItems.Id) WHERE VotingListItems.VotingList_Id = 1)[VotesCast]
                FROM VotingList where Groups_Id = {0} AND IsActive = 1";

                // Executhe the query
                VotationList = _context.Database.SqlQuery<VotationListViewModel>(Query, GROUPID).ToList();

            }
            catch (Exception ex)
            {
            }
            // Handling Errors

            // Return votation list
            return VotationList;

        }


    }
}