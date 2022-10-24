using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DataModel.EF
{
    [Table("Colors")]
    public partial class Colors
    {
        [Key]
        public long ID { get; set; }
        [Display(Name ="Tên Màu")]
        [StringLength(30)]
        public string Name { get; set; }

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
        [Display(Name ="Trạng Thái")]
        public bool Status { get; set; }
    }
}
