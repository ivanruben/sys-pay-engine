namespace DataManager
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DataManager.Models;
    using System.Collections.Generic;

    public partial class CalculatingPBI : DbContext
    {
        public CalculatingPBI()
            : base("name=CalculatingPBI")
        {
        }

        public DbSet<TransactionProcessing> TransactionProcessings { get; set; }
        public DbSet<ReferenceData> ReferenceDatas { get; set; }
        public DbSet<Pricing> Pricings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
