using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index()
        {
            return View();
        }
        ///tạo mới content
        [HttpGet]
        public ActionResult Create()
        {
            //gán setviewbag đưa ra create
            SetViewBag();
            return View();
        }
        ///hàm sửa content
        [HttpGet]
        public ActionResult Edit(long id)
        {
            //lấy ra ID từ content
            var dao = new Model.Dao.ContentDao();
            var content = dao.GetById(id);
            //gán setviewbag đưa ra create
            SetViewBag(content.CategoryID);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {

            }
            SetViewBag(model.CategoryID);
            return View();
        }
        [HttpPost]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid)
            {

            }

            SetViewBag();
            return View();
        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
    }
}