using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBackend.Areas.Admin.Controllers
{
    public class MenuAdminController : BaseController
    {
        // GET: Admin/MenuAdmin
        public ActionResult Index()
        {
            
            var model = new MenuDao().ListByID(1);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDao();

                long id = dao.Insert(menu);
                if (id > 0)
                {
                    setAL("Thêm menu thành công", "success");
                    return RedirectToAction("Index", "MenuAdmin");
                }
                else
                {
                    setAL("Thêm menu thành công", "error");
                    ModelState.AddModelError("", "Thêm User thành công");
                }
            }
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            new MenuDao().Delete(id);
            return RedirectToAction("Index");

        }

    }
}