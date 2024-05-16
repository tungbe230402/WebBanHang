using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class ProductImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductImage
        public ActionResult Index(int id)
        {
            ViewBag.productId = id;
            var items = db.productImages.Where(x => x.ProductId == id).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddImage(int productId, string url)
        {
            db.productImages.Add(new ProductImage {
                ProductId = productId,
                Image = url,
                IsDefault = false
            });
            db.SaveChanges();
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult Delete(int id) 
        {
            var item = db.productImages.Find(id);
            db.productImages.Remove(item);
            db.SaveChanges();
            return Json( new { success = true});
        }

        [HttpPost]
        public ActionResult IsDefault(int id)
        {
            var item = db.productImages.Find(id);
            if (item != null)
            {
                item.IsDefault = !item.IsDefault;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isDefault = item.IsDefault });
            }
            return Json(new { success = false });
        }
    }
}