namespace DataModel.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }
        [StringLength(50)]
        [Display(Name = "Tên tài Khoản")]
        public string UserName { get; set; }
        public bool? Status { get; set; }
        [StringLength(50)]
        [Display(Name = "Tài Khoản Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Số Điện Thoại")]
        public string Phone { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
