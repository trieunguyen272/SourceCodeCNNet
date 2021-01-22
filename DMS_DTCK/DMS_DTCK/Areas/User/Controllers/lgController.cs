using DMS_DTCK.Areas.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS_DTCK.Areas.User.Controllers
{
    public class lgController : Controller
    {
        // GET: User/lg
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Lg(LoginModel md)
        {
            return View();
        }
    }
}