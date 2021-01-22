using DMS_DTCK.Areas.User.Models;
using DMS_DTCK.Common;
using Models;
using Models.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS_DTCK.Areas.User.Controllers
{
    public class LoginController : Controller
    {
        // GET: Home/Login
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login1()
        //{
        //    LoginModel model = new LoginModel();
        //    var result = new AccountModel().Login(model.UserName, model.PassWord);
        //    if (result && ModelState.IsValid)
        //    {

        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác");
        //    }
        //    return View(model);
        //}
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                
                var dao = new UserDao();
                
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dao.GetByUserSV(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.MASV;
                    userSession.PassWord = user.MATKHAU;
                    userSession.FirstName = user.HOTENLOT;
                    userSession.LastName= user.TEN;
                    userSession.User = user.HOVATEN;
                    userSession.Birthday = user.NGAYSINH;
                    userSession.Gender = user.GIOITINH;
                    userSession.Address = user.DIACHI;
                    userSession.Identity_card = user.CMND;
                    userSession.Phone_number = user.SDT;
                    userSession.Class = user.LOP;
                    userSession.Faculty = user.KHOA;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    ModelState.AddModelError("", "Đn thành công sv");
                    return RedirectToAction("Index", "PHONGs", new { Area = "Student" });

                }
                if (result == 2)
                {
                    var user = dao.GetByUserSV(model.UserName);
                    var boarder = dao.GetByPhong(model.UserName);
                    var userSession = new UserLogin();
                    var boarderSession = new BoarderLogin();
                    userSession.UserName = user.MASV;
                    userSession.PassWord = user.MATKHAU;
                    userSession.FirstName = user.HOTENLOT;
                    userSession.LastName = user.TEN;
                    userSession.User = user.HOVATEN;
                    userSession.Birthday = user.NGAYSINH;
                    userSession.Gender = user.GIOITINH;
                    userSession.Address = user.DIACHI;
                    userSession.Identity_card = user.CMND;
                    userSession.Phone_number = user.SDT;
                    userSession.Class = user.LOP;
                    userSession.Faculty = user.KHOA;
                    boarderSession.UserName = boarder.MASV;
                    boarderSession.IDPhong = boarder.MAPHONG;
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    Session.Add(CommonBoarder.BOARDER_SESSION, boarderSession);
                    ModelState.AddModelError("", "Đn thành công sv");
                    return RedirectToAction("Index", "HDDIENNUOCs", new { Area = "Boarder" });

                }
                else if (result == 3)
                {
                    var admin = dao.GetByUserQL(model.UserName);
                    var adminSession = new AdminLogin();
                    adminSession.UserName = admin.MAQL;
                    adminSession.PassWord = admin.MATKHAU;
                    adminSession.FirstName = admin.HOTENLOT;
                    adminSession.LastName = admin.TEN;
                    adminSession.User = admin.HOVATEN;
                    adminSession.Birthday = admin.NGAYSINH;
                    adminSession.Gender = admin.GIOITINH;
                    adminSession.Address = admin.DIACHI;
                    adminSession.Identity_card = admin.CMND;
                    adminSession.Phone_number = admin.SDT;
                    adminSession.Position = admin.CHUCVU;
                    Session.Add(CommonAdmin.ADMIN_SESSION, adminSession);
                    ModelState.AddModelError("", "");
                    /*return RedirectToAction("Index", "Login");*///trang nhaan vien
                    return RedirectToAction("Index", "KHUNHAs", new { Area = "Admin" });
                }
                
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else
                {
                    ModelState.AddModelError("", "Mật khẩu không chính xác");
                }
            }
            else
            {
                ModelState.AddModelError("", "Chưa nhập thông tin tài khoản!");
            }
            return View("Login");
        }
        
    }
}