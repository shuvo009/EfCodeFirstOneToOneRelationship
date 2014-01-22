using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCodeFirstOneToOneRelationship
{
    public class EfContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>()
            //    .HasKey(temp => temp.StockId);
            modelBuilder.Entity<Stock>()
                .HasRequired(temp => temp.Product)
                .WithRequiredPrincipal(x => x.Stock);
            base.OnModelCreating(modelBuilder);
        }
    }

  
}
