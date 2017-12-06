namespace FinalCS460.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ITEMS")]
    public partial class ITEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ITEM()
        {
            BIDS = new HashSet<BID>();
        }

        public int ItemID { get; set; }

        [Required]
        [StringLength(64)]
        public string ItemName { get; set; }

        [Required]
        [StringLength(128)]
        public string ItemDesc { get; set; }

        public int SellerID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BID> BIDS { get; set; }

        public virtual SELLER SELLER { get; set; }
    }
}
