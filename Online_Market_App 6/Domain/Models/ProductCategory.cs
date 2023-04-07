using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; } = null!;
        public int SpecId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Specification Spec { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}
