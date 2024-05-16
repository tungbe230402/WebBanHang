using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Role
        public ActionResult Index()
        {
            var items = db.Roles.ToList();
            return View(items);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole model)
        {
            if(ModelState.IsValid)
            {
                var roleManage = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                roleManage.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var item = db.Roles.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                var roleManage = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                var role = roleManage.FindById(model.Id);
                if (role != null)
                {
                    role.Name = model.Name;
                    roleManage.Update(role);
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            var roleManage = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var role = roleManage.FindById(id);
            if (role != null)
            {
                roleManage.Delete(role);
                return Json(new {Success = true});
            }
            return Json(new {Success = false});
        }
    }
}