namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THANNHAN")]
    public partial class THANNHAN
    {
        [Key]
        public int MATHANNHAN { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã sinh viên")]
        public string MASV { get; set; }

        [StringLength(50)]
        [Display (Name = "Họ và tên cha")]
        [Required (ErrorMessage = "Bạn phải nhập họ và tên cha")]
        public string HOTENCHA { get; set; }

        [StringLength(50)]
        [Display(Name = "Nghề nghiệp cha")]
        [Required(ErrorMessage = "Bạn phải nhập nghề nghiệp cha")]
        public string NGHENGHIEPCHA { get; set; }

        [StringLength(10)]
        [Display(Name = "Số điện thoại cha")]
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại cha")]
        public string SDTCHA { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ và tên mẹ")]
        [Required(ErrorMessage = "Bạn phải nhập họ và tên mẹ")]
        public string HOTENME { get; set; }

        [StringLength(50)]
        [Display(Name = "Nghề nghiệp mẹ")]
        [Required(ErrorMessage = "Bạn phải nhập nghề nghiệp mẹ")]
        public string NGHENGHIEPME { get; set; }

        [StringLength(10)]
        [Display(Name = "Số điện thoại mẹ")]
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại mẹ")]
        public string SDTME { get; set; }
        [Display(Name = "Thân nhân SVNT")]
        public bool THANNHANSVNT { get; set; }

        public virtual SINHVIEN SINHVIEN { get; set; }
    }
}
