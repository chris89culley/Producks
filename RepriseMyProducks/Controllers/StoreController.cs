using Producks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using RepriseMyProducks.Dtos;

namespace RepriseMyProducks.Controllers
{

    public class StoreController : Controller
    {
        
        private StoreDb db = new StoreDb();
        private HttpClient client = new HttpClient();
        
        private IEnumerable<CategoryCutters> GetCategoryCutters()
        {
            try
            {
                HttpResponseMessage message = client.GetAsync("api/category").Result;
                if (message.IsSuccessStatusCode)
                {
                    return message.Content.ReadAsAsync<IEnumerable<CategoryCutters>>().Result;
                }
            }
            catch
            {
                return null;
            }

            return null;
        }



        private void mergeWithUndercutters()
        {
            client.BaseAddress = new System.Uri("http://undercutters.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.ParseAdd("appication/json");

            var newCategories = GetCategoryCutters().Where(c => !db.Categories.Any(s => s.Name.Equals(c.Name))).Select(x => new Producks.Model.Category
            {
                Active = true,
                Description = x.Description,
                Id = x.Id,
                Name = x.Name
            });

            db.Categories.AddRange(newCategories);

            

            


           

        }
        // GET: Store
        public ActionResult Index()
        {
            
            //We still want to show categories that are 'not active' that still have products in the store
            return View(db.Categories.Where(c => db.Products.FirstOrDefault(s => s.Category.Id == c.Id && s.Active) != null).ToList()); 
        }

        public ActionResult Display(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producks.Model.Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var products = db.Products.Where(s => s.Category.Id == category.Id && s.Active).ToList();
            return View(products);

        }
    }
}