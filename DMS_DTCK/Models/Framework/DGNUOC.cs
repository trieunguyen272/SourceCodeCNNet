namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DGNUOC")]
    public partial class DGNUOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DGNUOC()
        {
            HDDIENNUOCs = new HashSet<HDDIENNUOC>();
        }

        [Key]
        [Display(Name = "Mã đơn giá nước")]
        public int MADGNUOC { get; set; }
        [Display(Name = "Đơn giá nước")]
        [Required(ErrorMessage = "Bạn phải nhập đơn giá nước")]
        public double DONGIANUOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HDDIENNUOC> HDDIENNUOCs { get; set; }
    }
}
