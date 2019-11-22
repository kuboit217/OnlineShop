using Model.Dao;
using OnlineShop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSION, userSession);

                    return RedirectToAction("Index", "Home");
                }
                else if (result ==  0)
                {
                    ModelState.AddModelError("", "Không tồn tại tài khoản này!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn đang bị khóa!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không chính xác!");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }
            }

            return View("Index");
        }
    }
}