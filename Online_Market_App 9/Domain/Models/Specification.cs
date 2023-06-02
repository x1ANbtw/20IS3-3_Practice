using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Specification
    {
        public Specification()
        {
            ProductCategories = new HashSet<ProductCategory>();
            SpecsForProducts = new HashSet<SpecsForProduct>();
        }

        public int SpecId { get; set; }
        public string SpecName { get; set; } = null!;
        public int SpecValue { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<SpecsForProduct> SpecsForProducts { get; set; }
    }
}
