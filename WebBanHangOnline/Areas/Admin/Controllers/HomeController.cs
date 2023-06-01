using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize (Roles = "Admin, employee")]
    public class HomeController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult MenuTop()
        //{
        //    var items = db.Categories.OrderBy(x=>x.Postition).ToList();
        //    return PartialView("_MenuTop", items);
        //}
    }
}