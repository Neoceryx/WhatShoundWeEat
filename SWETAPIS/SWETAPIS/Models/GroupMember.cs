//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SWETAPIS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GroupMember
    {
        public int Id { get; set; }
        public int Groups_Id { get; set; }
        public int Users_Id { get; set; }
        public Nullable<System.DateTime> RegisterDate { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual User User { get; set; }
    }
}
