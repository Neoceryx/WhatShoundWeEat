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
    
    public partial class VotingListItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VotingListItem()
        {
            this.Votes = new HashSet<Vote>();
        }
    
        public int Id { get; set; }
        public int VotingList_Id { get; set; }
        public string ItenName { get; set; }
        public int Users_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vote> Votes { get; set; }
        public virtual VotingList VotingList { get; set; }
        public virtual User User { get; set; }
    }
}