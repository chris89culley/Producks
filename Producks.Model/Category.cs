
using System.ComponentModel.DataAnnotations;

namespace Producks.Model
{
    public class Category
    {
        public virtual int Id { get; set; }
        [Display(Name = "Category Name")]
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Active { get; set; }
    }
}
