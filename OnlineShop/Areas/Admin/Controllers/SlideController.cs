using Model.Dao;
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