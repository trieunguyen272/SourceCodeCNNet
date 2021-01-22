using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class AdminDao
    {
        QLKTXDbContext db = null;
        public AdminDao()
        {
            db = new QLKTXDbContext();
        }
        public bool InsertDienNuoc(string mp, int thang, int nam)
        {
            var ma = db.DIENNUOCs.Where(x => (x.MAPHONG == mp) && (x.THANG.Equals(thang))
                        && x.NAM.Equals(nam)).SingleOrDefault();
            if (ma == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int LaySoDien (string mp, int thang, int nam)
        {
            var phong = db.DIENNUOCs.Where(x => (x.MAPHONG == mp) && (x.THANG.Equals(thang))
                        && x.NAM.Equals(nam)).SingleOrDefault();
            return phong.CHISODIEN;
        }
        public int LaySoNuoc(string mp, int thang, int nam)
        {
            var phong = db.DIENNUOCs.Where(x => (x.MAPHONG == mp) && (x.THANG.Equals(thang))
                        && x.NAM.Equals(nam)).SingleOrDefault();
            return phong.CHISONUOC;
        }
        public bool InsertHDDienNuoc(string mp, int thang, int nam)
        {
            var ma = db.HDDIENNUOCs.Where(x => (x.MAPHONG == mp) && (x.THANG.Equals(thang)) && (x.NAM.Equals(nam))).SingleOrDefault();
            if (ma == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool InsertHDDN(int thang, int nam)
        {
            List<HDDIENNUOC> dsphong = db.HDDIENNUOCs.Where(x => (x.THANG.Equals(thang)) && (x.NAM.Equals(nam))).ToList();
            if (dsphong == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool insertKhuNha (string mk)
        {
            var ma = db.KHUNHAs.Where(x => (x.MAKHU == mk)).SingleOrDefault();
            if (ma == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool insertPhong(string mp)
        {
            var ma = db.PHONGs.Where(x => (x.MAPHONG == mp)).SingleOrDefault();
            if (ma == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
