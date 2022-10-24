namespace DataModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sale")]
    public partial class Sale
    {
        [Key]
        public long ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên Đợt Khuyến Mãi")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Tiêu Đề")]
        public string MetaTitle { get; set; }

        [Display(Name = "Ngày Bắt Đầu")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime? BeginDate { get; set; }

        [Display(Name = "Ngày Kết Thúc")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Ngày Tạo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Người Tạo")]
        public string CreatedBy { get; set; }
        [Display(Name = "Ngày Cập Nhật")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dd/MM/yyyy}")]

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Người Cập Nhật")]
        public string ModifiedBy { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool? Status { get; set; }
        [Display(Name = "Hiển Thị Ra Trang Chủ")]

        public bool? ShowOnHome { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
