using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class UserDao
    {
        QLKTXDbContext db = null;
        public UserDao()
        {
            db = new QLKTXDbContext();
        }
        public SINHVIEN GetByUserSV(string username)
        {
            return db.SINHVIENs.SingleOrDefault(x => x.MASV == username);
        }

        public QUANLY GetByUserQL(string username)
        {
            return db.QUANLies.SingleOrDefault(x => x.MAQL ==username);
        }
        public PHONG GetByMP (string id)
        {
            return db.PHONGs.SingleOrDefault(x => x.MAPHONG.Equals(id));
        }
        public int Login(string User, string Pass)
        {
            var querysv = db.SINHVIENs.SingleOrDefault(x => x.MASV == User);
            
            var queryql = db.QUANLies.SingleOrDefault(x => x.MAQL == User);
            if (querysv == null && queryql == null)
            {
                return 0;
            }
            else if (querysv != null && querysv.MATKHAU != Pass)
            {
                return -1;
            }
            else if (querysv != null && querysv.MATKHAU == Pass && querysv.SVNOITRU == false)
            {
                return 1;
            }
            else if (querysv != null && querysv.MATKHAU == Pass && querysv.SVNOITRU == true)
            {
                return 2;
            }
            else if (queryql != null && queryql.MATKHAU != Pass)
            {
                return -3;
            }
            else
            {
                return 3;
            }

        }
        public HOPDONG GetByPhong(string username)
        {
            return db.HOPDONGs.SingleOrDefault(x => (x.MASV == username) && (x.HIEULUCHD == true));
        }
        public List<PHONG> DanhSach()
        {
            return db.PHONGs.ToList();
        }
    }
}
