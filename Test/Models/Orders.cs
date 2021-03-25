using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Orders
    {
        public Order tOrder { get; set; }
        public OrderItem tOrderItem { get; set; }
        public Provider tProvider { get; set; }
        public List<OrderItem> lstOrderItem { get; set; }
        public List<Order> lstOrder { get; set; }
        public List<Provider> lstProvider { get; set; }
        public Dictionary<int, string> dicProvider { get; set; }      
        public string oNumber { get; set; }
        public DateTime oDate { get; set; }
        public int oProviderId { get; set; }
        public int countOrder { get; set; }
        public string SearchProvider { get; set; }


    }
}