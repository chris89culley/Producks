
using System.ComponentModel.DataAnnotations;

namespace Producks.Model
{
    public class Brand
    {
        public virtual int Id { get; set; }
        [Display(Name = "Brand Name")]
        public virtual string Name { get; set; }
        public virtual bool Active { get; set; }
    }
}
