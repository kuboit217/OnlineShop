using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using OnlineShop.Common;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page =1,int  pageSize = 10)
        {
            var dao = new UserDao();            
            var model = dao.ListAllPaging(searchString, page,pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        // hàm lấy thông tin của 1 user theo khóa chính
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        //Thêm mới user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                //mã hóa md5 cho password
                var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                user.Password = encryptedMd5Pas;
                user.CreateDate = DateTime.Now;
                user.ConfirmPassword = user.Password;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("","Thêm người dùng không thành công");
                }
            }
            else
            {
                return View("AddUser");
            }
            return View("Index");
        }
        // hàm cập nhật thông tin user
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                //kiểm tra password có rỗng hãy không
                if (!string.IsNullOrEmpty(user.Password))
                {
                    //mã hóa md5 cho password
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                    user.Password = encryptedMd5Pas;
                    user.ConfirmPassword = user.Password;
                }
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập nhật user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật người dùng người dùng không thành công");
                }
            }
            else
            {
                return View("Edit");
            }
            return View("Index");
        }
        //hàm xóa một bản ghi trong user
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            SetAlert("Xóa user thành công", "success");
            return RedirectToAction("Index");
        }
        //hàm Json gọi nút kích hoạt
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}