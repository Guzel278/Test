using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class OrderItems
    {
        public OrderItem tOrderItem { get; set; }
        public List<OrderItem> lstOrderItem { get; set; }
        public int countOrderItem { get; set; }
        public string oiName { get; set; }
        public int oiOrderId { get; set; }
        public decimal oiQuantity { get; set; }
        public string oiUnit { get; set; }
        public int orderId { get; set; }
        public OrderItem currentOrderItem { get; set; }
    }
}