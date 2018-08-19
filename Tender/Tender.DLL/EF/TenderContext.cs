using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tender.DAL.Entities;
namespace Tender.DAL.EF
{
    public class TenderContext : DbContext
    {
        public TenderContext() : base("TenderDB") {
            Database.SetInitializer(new TenderDBInitializer()); }

        public virtual DbSet<Tend> Tenders { get; set; }
        public virtual DbSet<Organisation> Organisations { get; set; }
        public virtual DbSet<Kind> Kinds { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Classification> Classifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.Tends);

            modelBuilder.Entity<Kind>()
                .HasMany(e => e.Tends);
        }
    }
    

}
