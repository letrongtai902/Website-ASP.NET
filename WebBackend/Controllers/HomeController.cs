using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBackend.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        [ChildActionOnly]
        public ActionResult _Menu()
        {
            var model = new MenuDao().ListByID(1);
            return PartialView(model);
        }
    }
}