using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.EF
{
    [Table("InforCompany")]
    public partial class InforCompany
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InforCompany()
        {
            Contents = new HashSet<Content>();
        }
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Tài Khoản Email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "Số Điện Thoại")]
        public string Phone { get; set; }
        public string Image { get; set; }
        [ReadOnly(true)]
        [Display(Name = "Ngày Tạo")]
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content> Contents { get; set; }
    }
}
