namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIENNUOC")]
    public partial class DIENNUOC
    {
        [Key]
        [Display(Name = "Mã điện nước")]
        public int MADIENNUOC { get; set; }

        [StringLength(20)]
        [Display(Name = "Mã phòng")]
        public string MAPHONG { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã quản lý")]
        public string MAQL { get; set; }
        [Display(Name = "Tháng")]
        [Required(ErrorMessage = "Bạn phải nhập tháng")]
        public int THANG { get; set; }
        [Display(Name = "Năm")]
        [Required(ErrorMessage = "Bạn phải nhập năm")]
        public int NAM { get; set; }
        [Display(Name = "Chỉ số điện")]
        [Required(ErrorMessage = "Bạn phải nhập chỉ số điện")]
        public int CHISODIEN { get; set; }
        [Display(Name = "Chỉ số nước")]
        [Required(ErrorMessage = "Bạn phải nhập chỉ số nước")]
        public int CHISONUOC { get; set; }

        public virtual PHONG PHONG { get; set; }

        public virtual QUANLY QUANLY { get; set; }
    }
}
