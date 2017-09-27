using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepriseMyProducks.ViewModels
{
    public class ProductVm
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Price { get; set; }
   

        public int StockLevel { get; set; }

        public  string StockStatus
        {
            get {
                return (StockLevel > 0) ? "in stock" : "not in stock";
            }

            set {
                return;
            }
        }


        public virtual string Category { get; set; }
        public virtual string Brand { get; set; }

     
       
    }
}