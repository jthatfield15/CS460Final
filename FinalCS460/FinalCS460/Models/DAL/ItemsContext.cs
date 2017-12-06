namespace FinalCS460.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ItemsContext : DbContext
    {
        public ItemsContext()
            : base("name=ItemsContext")
        {
        }

        public virtual DbSet<BID> BIDS { get; set; }
        public virtual DbSet<BUYER> BUYERS { get; set; }
        public virtual DbSet<ITEM> ITEMS { get; set; }
        public virtual DbSet<SELLER> SELLERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
