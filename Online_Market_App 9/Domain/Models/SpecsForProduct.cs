﻿using System;
using System.Collections.Generic;

namespace Domain.Models
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
