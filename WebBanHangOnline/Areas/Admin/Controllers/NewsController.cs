using System;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, employee")]

    public class NewsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/News 
//phân trang = pagelist.mvc
        public ActionResult Index(String Searchtext, int? page)
        {
            var pageSize = 5;
            if(page == null)
            {
                page = 1;
            }
            IEnumerable<News> items = db.News.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Alias.Contains(Searchtext) || x.Title.Contains(Searchtext)).ToList();
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);        
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(News Model)
        {
            if (ModelState.IsValid)
            {
                Model.CreateDate= DateTime.Now;
                Model.CategoryId = 5;
                Model.ModifiedDate= DateTime.Now;
                Model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(Model.Title);
                db.News.Add(Model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Model);
        }

        //Sửa
        public ActionResult Edit(int id)
        {
            var item = db.News.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News Model)
        {
            if (ModelState.IsValid)
            {
               
                //Model.CategoryId = 5;
                Model.ModifiedDate = DateTime.Now;
                Model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(Model.Title);
                db.News.Attach(Model);
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
            var item = db.News.Find(id); //xem bàn ghi tồn tại k
            if (item != null)
            {
                //var DeleteItem = db.Categories.Attach(item);
                db.News.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.News.Find(id); //xem bàn ghi tồn tại k
            if (item != null)
            {
                //var DeleteItem = db.Categories.Attach(item);
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true , isActive = item.IsActive});
            }
            return Json(new { success = false });
        }

        //xóa tất cả TIN

        public ActionResult DeleteAll(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if(items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.News.Find(Convert.ToInt32(item));   
                        db.News.Remove(obj);
                        db.SaveChanges();   
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}