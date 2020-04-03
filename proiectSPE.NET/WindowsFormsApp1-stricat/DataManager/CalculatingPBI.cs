namespace DataManager
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DataManager.Models;
    using System.Collections.Generic;

  /*  public partial class CalculatingPBI : System.Data.Entity.DbContext
    {
        public CalculatingPBI()
            : base("name=CalculatingPBI")
        {
        }
*/
        public class CalculatingPBI : System.Data.Entity.DbContext
        {
                  
        public System.Data.Entity.DbSet<TransactionProcessing> TransactionProcessings { get; set; }
        public System.Data.Entity.DbSet<Contract> Contract { get; set; }
        public System.Data.Entity.DbSet<Pricing> Pricings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
