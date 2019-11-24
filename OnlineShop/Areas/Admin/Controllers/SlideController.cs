using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SlideController : BaseController
    {
        // GET: Admin/Slide
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new SlideDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult AddSlide()
        {
            return View();
        }
        //hàm xóa một bản ghi trong user
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new SlideDao().Delete(id);
            SetAlert("Xóa user thành công", "success");
            return RedirectToAction("Index");
        }

        //Thêm mới user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slide slide)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDao();

                
                slide.CreateDate = DateTime.Now;
                slide.CreateBy = Common.CommonConstants.USER_SESSION;
                long id = dao.Insert(slide);
                if (id > 0)
                {
                    SetAlert("Thêm slides thành công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm slides không thành công");
                }
            }
            else
            {
                return View("AddSlide");
            }
            return View("Index");
        }

        // hàm lấy thông tin của 1 user theo khóa chính
        public ActionResult EditSide(int id)
        {
            var slide = new SlideDao().ViewDetail(id);
            return View(slide);
        }

        // hàm cập nhật thông tin user
        [HttpPost]
        public ActionResult EditSlide(Slide slide)
        {
            if (ModelState.IsValid)
            {
                var result = new SlideDao().Update(slide);
                if (result)
                {
                    SetAlert("Cập nhật slideshow thành công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật slideshow không thành công");
                }
            }
            else
            {
                return View("EditSlide");
            }
            return View("Index");
        }

        //ham đổi status
        public JsonResult ChangeStatus(long id)
        {
            var result = new SlideDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}