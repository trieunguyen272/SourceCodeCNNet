namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOPDONG")]
    public partial class HOPDONG
    {
        [Key]
        [Display(Name = "Mã hợp đồng")]
        public int MAHOPDONG { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã sinh viên")]
        public string MASV { get; set; }

        [StringLength(20)]
        [Display(Name = "Mã phòng")]
        public string MAPHONG { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày lập")]
        public DateTime NGAYLAP { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày bắt đầu")]
        public DateTime NGAYBATDAU { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày kết thúc")]
        public DateTime NGAYKETTHUC { get; set; }
        [Display(Name = "Hiệu lực HĐ")]
        public bool HIEULUCHD { get; set; }

        public virtual PHONG PHONG { get; set; }

        public virtual SINHVIEN SINHVIEN { get; set; }
    }
}
