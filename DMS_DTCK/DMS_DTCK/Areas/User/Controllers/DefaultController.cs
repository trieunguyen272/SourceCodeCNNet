using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS_DTCK.Areas.User.Controllers
{
    public class DefaultController : Controller
    {
        // GET: User/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}