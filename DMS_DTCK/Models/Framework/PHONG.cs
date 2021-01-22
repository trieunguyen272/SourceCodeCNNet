namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHONG")]
    public partial class PHONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG()
        {
            DIENNUOCs = new HashSet<DIENNUOC>();
            HDDIENNUOCs = new HashSet<HDDIENNUOC>();
            HOPDONGs = new HashSet<HOPDONG>();
        }

        [Key]
        [StringLength(20)]
        [Display(Name = "Mã phòng")]
        [Required(ErrorMessage = "Bạn phải nhập mã phòng")]
        public string MAPHONG { get; set; }

        [Display(Name = "Số phòng")]
        [Required(ErrorMessage = "Bạn phải nhập số phòng")]
        public int SOPHONG { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã khu")]
        public string MAKHU { get; set; }

        [Display(Name = "Số lượng sinh viên")]
        [Required(ErrorMessage = "Bạn phải nhập số lượng sinh viên")]
        public int SOLUONGSV { get; set; }
        [Display(Name = "Giá phòng")]
        [Required(ErrorMessage = "Bạn phải nhập giá phòng")]
        public double GIAPHONG { get; set; }
        [Display(Name = "Số chỗ trống")]
        [Required(ErrorMessage = "Bạn phải nhập số chỗ trống")]
        public int SOCHOTRONG { get; set; }

        [StringLength(200)]
        [Display(Name = "Mô tả khác")]
        [Required(ErrorMessage = "Bạn phải nhập mô tả khác")]
        public string MOTAKHAC { get; set; }
        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "Bạn phải chọn trạng thái")]
        public bool TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIENNUOC> DIENNUOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HDDIENNUOC> HDDIENNUOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }

        public virtual KHUNHA KHUNHA { get; set; }
    }
}
