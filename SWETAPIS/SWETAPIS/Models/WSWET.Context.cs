﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WSWETEntities : DbContext
    {
        public WSWETEntities()
            : base("name=WSWETEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdmissionRequest> AdmissionRequests { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<StatusRequest> StatusRequests { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<VotingList> VotingLists { get; set; }
        public virtual DbSet<VotingListItem> VotingListItems { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
