using System;
using System.Collections.Generic;
using Online_Market_App.Models;

namespace Online_Market_App.Models
{
    public partial class SpecsForProduct
    {
        public int SpecId { get; set; }
        public int ProductId { get; set; }
        public int SpecProductId { get; set; }
        public int Value { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Specification Spec { get; set; } = null!;
    }
}
