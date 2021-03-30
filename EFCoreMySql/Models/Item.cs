using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreMySql.Models
{
    public partial class Item
    {
        public Item()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Amount { get; set; }
        public byte ItemStatus { get; set; }
        public string ItemDescription { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
