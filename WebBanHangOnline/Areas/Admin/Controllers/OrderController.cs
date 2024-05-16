using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class OrderController : Controller
    {
        // GET: Admin/Order
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            var item = db.Orders.OrderByDescending(x => x.CreatedDate).ToList();

            if(page == null)
            {
                page = 1;
            }
            var pageSize = 10;
            var pageNumber = page.HasValue ? Convert.ToInt32(page) : 1;            
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(item.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult View(int id)
        {
            var item = db.Orders.Find(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult UpdateStatus(int id, string status)
        {
            var item = db.Orders.Find(id);
            if(item != null)
            {
                db.Orders.Attach(item);
                item.TypePayment = status;
                db.Entry(item).Property(x => x.TypePayment).IsModified = true;
                db.SaveChanges();
                return Json(new {message = "Success", Success = true});
            }
            return Json(new { message = "UnSuccess", Success = false });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Orders.Find(id);
            if (item != null)
            {
                db.Orders.Remove(item);
                db.SaveChanges();
                return Json(new { Success = true });
            }
            return Json(new { Success = false });
        }
    }
}