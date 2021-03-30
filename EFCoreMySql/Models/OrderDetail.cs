using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreMySql.Models
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
