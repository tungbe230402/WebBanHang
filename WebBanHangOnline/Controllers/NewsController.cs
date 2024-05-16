using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            var pageSize = 3;
            if(page == null)
            {
                page = 1;
            }
            var pageNumber = page.HasValue ? Convert.ToInt32(page.Value) : 1;
            IEnumerable<News> items = db.News.OrderByDescending(x => x.CreatedDate);
            items = items.ToPagedList(pageNumber,pageSize);          
            return View(items);
        }

        public ActionResult Detail(int id)
        {
            var item = db.News.Find(id);
            return View(item);
        }

        public ActionResult Partial_News_Home()
        {
            var items = db.News.Take(3).OrderByDescending(x => x.CreatedDate);
            return PartialView(items);
        }
    }
}