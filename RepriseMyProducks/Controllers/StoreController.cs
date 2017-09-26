using Producks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RepriseMyProducks.Controllers
{
    public class StoreController : Controller
    {

        private StoreDb db = new StoreDb();
        // GET: Store
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Display(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var products = db.Products.Where(s => s.Category.Id == category.Id && s.Active).ToList();
            return View(products);

        }
    }
}