using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RepriseMyProducks.Controllers
{
    public class ExportsController : ApiController
    {
        private Producks.Model.StoreDb db = new Producks.Model.StoreDb();

        // GET: api/Brands
        [HttpGet]
        [Route("api/Brands")]
        public IEnumerable<Dtos.Brand> GetBrands()
        {
            return db.Brands
                     .AsEnumerable()
                     .Select(b => new Dtos.Brand
                     {
                        Id = b.Id,
                        Name = b.Name,
                        Active = b.Active
                     });
        }
        
        [HttpGet]
        [Route("api/Products")]
        public IEnumerable<Dtos.Product> getProducts( int? price = null, String cat = null, String brand = null)
        {
            return db.Products.AsEnumerable()
                    .Select(b => new Dtos.Product
                    {
                        Id = b.Id,
                        CategoryId = b.CategoryId,
                        BrandId = b.BrandId,
                        Name = b.Name,
                        Description = b.Description,
                        Price = b.Price,
                        StockLevel = b.StockLevel,
                        Active = b.Active,
                        Category = b.Category.Name,
                        Brand = b.Brand.Name

                    }).Where(l => (l.Category == cat || cat == null) && (l.Price == price || price == null) && (brand == l.Brand || brand == null));
        }


        [HttpGet]
        [Route("api/Category")]
        public IEnumerable<Dtos.Category> getCategorys()
        {
            return db.Categories.AsEnumerable()
                .Select(c => new Dtos.Category
                {
                    Active = c.Active,
                    Description = c.Description,
                    Id = c.Id,
                    Name = c.Name
                });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}