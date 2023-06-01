using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Posts
        public ActionResult Index()
        {
            var items = db.Posts.ToList();

       
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Posts Model)
        {
            if (ModelState.IsValid)
            {
                Model.CreateDate = DateTime.Now;
                Model.CategoryId = 5;
                Model.ModifiedDate = DateTime.Now;
                Model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(Model.Title);
                db.Posts.Add(Model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Model);
        }

        //Sửa
        public ActionResult Edit(int id)
        {
            var item = db.Posts.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Posts Model)
        {
            if (ModelState.IsValid)
            {

                //Model.CategoryId = 5;
                Model.ModifiedDate = DateTime.Now;
                Model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(Model.Title);
                db.Posts.Attach(Model);
                db.Entry(Model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Model);
        }
        //xóatin tuc
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Posts.Find(id); //xem bàn ghi tồn tại k
            if (item != null)
            {
                //var DeleteItem = db.Categories.Attach(item);
                db.Posts.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.Posts.Find(id); //xem bàn ghi tồn tại k
            if (item != null)
            {
                //var DeleteItem = db.Categories.Attach(item);
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
            }
            return Json(new { success = false });
        }

        //xóa tất cả TIN

        public ActionResult DeleteAll(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.Posts.Find(Convert.ToInt32(item));
                        db.Posts.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}