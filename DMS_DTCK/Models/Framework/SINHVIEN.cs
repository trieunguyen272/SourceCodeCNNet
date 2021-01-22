namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SINHVIEN")]
    public partial class SINHVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SINHVIEN()
        {
            HOPDONGs = new HashSet<HOPDONG>();
            THANNHANs = new HashSet<THANNHAN>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name = "Mã sinh viên")]
        [Required(ErrorMessage = "Bạn phải nhập mã sinh viên")]
        public string MASV { get; set; }

        [StringLength(200)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string MATKHAU { get; set; }

        [Display(Name = "Họ và tên lót")]
        [Required(ErrorMessage = "Bạn phải nhập họ và tên lót")]
        [StringLength(30)]
        public string HOTENLOT { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Bạn phải nhập tên")]
        [StringLength(20)]
        public string TEN { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Bạn phải nhập họ và tên")]
        [StringLength(50)]
        public string HOVATEN { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Bạn phải nhập ngày sinh")]
        public DateTime NGAYSINH { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Bạn phải chọn giới tính")]
        public bool GIOITINH { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ")]
        [StringLength(50)]
        public string DIACHI { get; set; }

        [Display(Name = "Số CMND")]
        [Required(ErrorMessage = "Bạn phải nhập số CMND")]
        [StringLength(20)]
        public string CMND { get; set; }

        [Display(Name = "SDT")]
        [Required(ErrorMessage = "Bạn phải nhập SDT")]
        [StringLength(10)]
        public string SDT { get; set; }

        [Display(Name = "Lớp")]
        [Required(ErrorMessage = "Bạn phải nhập lớp")]
        [StringLength(30)]
        public string LOP { get; set; }

        [Display(Name = "Khoa")]
        [Required(ErrorMessage = "Bạn phải nhập khoa")]
        [StringLength(30)]
        public string KHOA { get; set; }
        [Display(Name = "Ảnh")]
        [Column(TypeName = "image")]
        public byte[] ANH { get; set; }
        [Display(Name = "SV nội trú")]
        public bool SVNOITRU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOPDONG> HOPDONGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<THANNHAN> THANNHANs { get; set; }
    }
}
