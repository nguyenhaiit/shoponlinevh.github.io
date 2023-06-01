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
    public class ProductCategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            var items = db.ProductCategories;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductCategory Model, string url)
        {
            if(ModelState.IsValid)
            {
                Model.CreateDate = DateTime.Now;     
                Model.ModifiedDate = DateTime.Now;
                Model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(Model.Title);
                
                db.ProductCategories.Add(Model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        //Sửa
        public ActionResult Edit(int id)
        {
            var item = db.ProductCategories.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory Model)
        {
            if (ModelState.IsValid)
            {
                //Model.CategoryId = 5;       
                Model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(Model.Title);
                var getPC = db.ProductCategories.Find(Model.Id);
                getPC.Title = Model.Title;
                getPC.Alias = Model.Alias;
                getPC.Description = Model.Description;
                getPC.SeoKeywords = Model.SeoKeywords;
                getPC.SaleTitle = Model.SaleTitle;
                getPC.SeoDescription = Model.SeoDescription;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Model);
        }
        //xóatin tuc
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductCategories.Find(id); //xem bàn ghi tồn tại k
            if (item != null)
            {
                //var DeleteItem = db.Categories.Attach(item);
                db.ProductCategories.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}