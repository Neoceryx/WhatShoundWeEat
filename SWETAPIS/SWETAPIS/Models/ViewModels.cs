using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWETAPIS.Models
{
    public class ViewModels
    {
    }

    public class GroupsViewModel {
        public int Id { get; set; }
        public String GroupName { get; set; }
        public int Users_Id { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int AdmissionRequests { get; set; }
    }

}