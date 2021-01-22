using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS_DTCK.Common
{
    [Serializable]
    public class AdminLogin
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string User { get; set; }
        public DateTime Birthday { get; set; }
        public Boolean Gender { get; set; }
        public string Address { get; set; }
        public string Identity_card { get; set; }
        public string Phone_number { get; set; }
        public string Position { get; set; }
    }
}