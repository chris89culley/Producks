using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepriseMyProducks.Dtos
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual int BrandId { get; set; }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Price { get; set; }
        public virtual int StockLevel { get; set; }
        public virtual bool Active { get; set; }

        public virtual string Category { get; set; }
        public virtual string Brand { get; set; }
    }
}