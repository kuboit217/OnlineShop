using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AboutController : BaseController
    {
        // GET: Admin/About
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new AboutDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        //hàm thêm phần giới thiệu
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        //hàm Json gọi nút kích hoạt
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new AboutDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}