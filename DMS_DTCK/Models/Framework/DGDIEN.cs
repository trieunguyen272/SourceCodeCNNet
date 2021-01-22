namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DGDIEN")]
    public partial class DGDIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DGDIEN()
        {
            HDDIENNUOCs = new HashSet<HDDIENNUOC>();
        }

        [Key]
        [Display(Name = "Mã đơn giá điện")]
        public int MADGDIEN { get; set; }
        [Display(Name = "Đơn giá điện")]
        [Required(ErrorMessage = "Bạn phải nhập đơn giá điện")]
        public double DONGIADIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HDDIENNUOC> HDDIENNUOCs { get; set; }
    }
}
