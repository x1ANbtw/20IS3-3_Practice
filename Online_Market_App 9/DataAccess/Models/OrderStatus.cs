using System;
using System.Collections.Generic;
using Online_Market_App.Models;

namespace Online_Market_App.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
