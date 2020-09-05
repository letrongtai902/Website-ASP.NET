using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using PagedList;
using WebBackend.Common;

namespace WebBackend.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1 ,int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(UserWeb user )
        {
            if(ModelState.IsValid)
            {
                var dao = new UserDao();

                var pass = Encrytor.MD5Hash(user.Password);
                user.Password = pass;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    setAL("Thêm user thành công","success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    setAL("Thêm user thành công", "error");
                    ModelState.AddModelError("", "Thêm User thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(UserWeb user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var pass = Encrytor.MD5Hash(user.Password);
                user.Password = pass;

                bool result = dao.update(user);
                if (result)
                {
                    setAL("Sửa user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    setAL("Sửa user không thành công", "error");
                    ModelState.AddModelError("", "Cập nhật User thành công");
                }
            }
            return View("Index");
        }
    }
}