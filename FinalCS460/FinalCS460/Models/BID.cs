namespace FinalCS460.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BIDS")]
    public partial class BID
    {
        public int BidID { get; set; }

        [Required]
        [StringLength(16)]
        public string Price { get; set; }

        public DateTime BidDateTime { get; set; }

        public int ItemID { get; set; }

        public int BuyerID { get; set; }

        public virtual BUYER BUYER { get; set; }

        public virtual ITEM ITEM { get; set; }
    }
}
