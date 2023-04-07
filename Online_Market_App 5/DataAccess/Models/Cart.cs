using System;
using System.Collections.Generic;

namespace Online_Market_App.Models
{
    public partial class Cart
    {
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
