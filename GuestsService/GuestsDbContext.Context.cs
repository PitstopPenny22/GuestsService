﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Common;

namespace GuestsService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GuestsDbContext : DbContext
    {
        public GuestsDbContext(DbConnection dbConnection)
            : base(dbConnection, false)
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<HotelRequirement> HotelRequirement { get; set; }
        public virtual DbSet<Household> Household { get; set; }
        public virtual DbSet<RsvpStatus> RsvpStatus { get; set; }
    }
}
