﻿using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Model.EF;

namespace WebBackend.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ContentDao();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDao();
            var content = dao.GetByID(id);
            SetViewBag(content.CategoryID);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Model.EF.Content model)
        {
            if (ModelState.IsValid)
            {

            }
            SetViewBag();
            return View(model.CategoryID);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Model.EF.Content model)
        {
            if(ModelState.IsValid)
            {
                var dao = new ContentDao();

                long id = dao.Insert(model);
                if (id > 0)
                {
                    setAL("Thêm tin tức thành công", "success");
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    setAL("Thêm tin tức không thành công", "error");
                    ModelState.AddModelError("", "Thêm User thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            new ContentDao().Delete(id);
            return RedirectToAction("Index");

        }
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListALL(),"ID","Name",selectedId);
        }
    }
}