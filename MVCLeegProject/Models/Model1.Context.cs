﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCLeegProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_A42A9B_Aveleijn2018Entities4 : DbContext
    {
        public DB_A42A9B_Aveleijn2018Entities4()
            : base("name=DB_A42A9B_Aveleijn2018Entities4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<IndicatieBehoeften> IndicatieBehoeftens { get; set; }
        public virtual DbSet<IndicatieNiveau> IndicatieNiveaux { get; set; }
        public virtual DbSet<checkBoxMap> checkBoxMaps { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Formulier_tt> Formulier_tt { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
