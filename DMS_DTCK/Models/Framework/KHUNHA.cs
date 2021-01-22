namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHUNHA")]
    public partial class KHUNHA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHUNHA()
        {
            PHONGs = new HashSet<PHONG>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name ="Mã khu nhà")]
        [Required (ErrorMessage ="Bạn phải nhập mã khu nhà")]
        public string MAKHU { get; set; }

        [StringLength(20)]
        [Display(Name = "Tên khu nhà")]
        [Required(ErrorMessage = "Bạn phải nhập tên khu nhà")]
        public string TENKHU { get; set; }

        [StringLength(100)]
        [Display(Name = "Mô tả khác")]
        [Required(ErrorMessage = "Bạn phải nhập mô tả khác")]
        public string MOTAKHAC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHONG> PHONGs { get; set; }
    }
}
