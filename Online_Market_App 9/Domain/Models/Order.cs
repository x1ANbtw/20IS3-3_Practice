using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int StatusId { get; set; }
        public int ProductCount { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual OrderStatus Status { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
