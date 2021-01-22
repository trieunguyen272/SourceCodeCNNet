namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HDDIENNUOC")]
    public partial class HDDIENNUOC
    {
        [Key]
        [Display(Name = "Mã hóa đơn")]
        public int MAHOADON { get; set; }

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
        [Display(Name = "Chỉ số điện cũ")]
        public int CHISODIENCU { get; set; }
        [Display(Name = "Chỉ số điện mới")]
        public int CHISODIENMOI { get; set; }
        [Display(Name = "Đơn giá điện")]
        public int? MADGDIEN { get; set; }
        [Display(Name = "Tiền điện")]
        public double TIENDIEN { get; set; }
        [Display(Name = "Chỉ số nước cũ")]
        public int CHISONUOCCU { get; set; }
        [Display(Name = "Chỉ số nước mới")]
        public int CHISONUOCMOI { get; set; }
        [Display(Name = "Đơn giá nước")]
        public int? MADGNUOC { get; set; }
        [Display(Name = "Tiền nước")]
        public double TIENNUOC { get; set; }
        [Display(Name = "Tổng tiền")]
        public double TONGTIEN { get; set; }
        [Display(Name = "Trạng thái TT")]
        public bool TRANGTHAITHANHTOAN { get; set; }

        public virtual DGDIEN DGDIEN { get; set; }

        public virtual DGNUOC DGNUOC { get; set; }

        public virtual PHONG PHONG { get; set; }

        public virtual QUANLY QUANLY { get; set; }
    }
}
