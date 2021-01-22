using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class StudentDao
    {
        QLKTXDbContext db = null;
        public StudentDao()
        {
            db = new QLKTXDbContext();
        }
        public void UpdateSoChoTrong(string id)
        {
            var phong = db.PHONGs.Find(id);
            phong.SOCHOTRONG = phong.SOCHOTRONG - 1;

            db.SaveChanges();
        }
    }
}
