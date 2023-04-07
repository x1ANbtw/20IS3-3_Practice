using System;
using System.Collections.Generic;

namespace Online_Market_App.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            SpecsForProducts = new HashSet<SpecsForProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public int ProductCategoryId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ProductCategory ProductCategory { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SpecsForProduct> SpecsForProducts { get; set; }
    }
}
