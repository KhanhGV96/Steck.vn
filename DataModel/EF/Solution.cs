namespace DataModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Solution")]
    public partial class Solution
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Solution()
        {
            Contents = new HashSet<Content>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public long? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }
        [StringLength(1000000000)]
        public string Description { get; set; }

        public bool Status { get; set; }

        public bool? ShowOnHome { get; set; }

        [StringLength(2)]
        public string Language { get; set; }
        [StringLength(250)]
        public string Image { get; set; }
        public long? CategoryID { get; set; }
        public DateTime? TopHot { get; set; }
        public int? ViewCount { get; set; }
        [StringLength(500)]
        public string Tags { get; set; }
        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content> Contents { get; set; }
    }
}
