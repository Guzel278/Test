using Test.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Test.Models.Service;


namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private UOW dbContext = new UOW();
        public TestEntities db = new TestEntities();
        public ActionResult Index(Orders model)
        {
            model = model == null ? new Orders() : model;


            model.lstOrder = GetLstOrder();
            model.lstOrder = model.lstOrder.OrderByDescending(c => c.Date).ToList();
            model.lstProvider = GetLstProvider();
            if (model.lstProvider != null)
            {
                model.dicProvider = GetDicProvidert(model);
            }
            model.countOrder = model.lstOrder.Count() + 1;
            model.oDate = DateTime.Now;

            if (model.SearchProvider != null)
            {
                model.lstProvider = model.lstProvider.Where(i => i.Id.ToString().Contains(model.SearchProvider) || i.Id.ToString() == model.SearchProvider).Distinct().ToList();
            }

            return View("Index", model);
        }

        public ActionResult Index1(OrderItems model, int id)
        {
            model = model == null ? new OrderItems() : model;
            model.lstOrderItem = GetLstOrderItem(id);
            model.orderId = id;
            return View("OrderItems", model);
        }

        public ActionResult AddNewItem(OrderItems model, int id)
        {
            model = model == null ? new OrderItems() : model;
            model.oiOrderId = id;
            model.lstOrderItem = GetLstOrderItem(id);
            model.countOrderItem = model.lstOrderItem.Count() + 1;
            return View("NewOrderItem", model);
        }

        public List<OrderItem> GetLstOrderItem(int id)
        {
            List<OrderItem> lstOrderItem = new List<OrderItem>();
            foreach (OrderItem item in dbContext.lstOrderItem(id))
            {
                lstOrderItem.Add(item);
            }
            return lstOrderItem;
        }

        private List<Order> GetLstOrder()
        {
            List<Order> lstOrder = new List<Order>();
            foreach (Order item in dbContext.lstOrder())
            {
                lstOrder.Add(item);
            }
            return lstOrder;
        }
        private List<Provider> GetLstProvider()
        {
            List<Provider> lstProvider = new List<Provider>();
            foreach (Provider item in dbContext.lstProvider())
            {
                lstProvider.Add(item);
            }
            return lstProvider;
        }

        private Dictionary<int, string> GetDicProvidert(Orders model)
        {
            Dictionary<int, string> dicProvider = new Dictionary<int, string>();
            foreach (Provider item in model.lstProvider)
            {
                dicProvider.Add(item.Id, item.Name);
            }
            return dicProvider;
        }
        public void Save(Orders model)
        {
            model.tOrder = new Order();

            try
            {
                model.tOrder.Id = model.countOrder;
                model.tOrder.Number = model.oNumber;
                model.tOrder.Date = model.oDate;
                model.tOrder.ProviderId = model.oProviderId;
                dbContext.Repository<Order>().Create(model.tOrder);
                dbContext.Save();
            }
            catch (IOException e)
            {

            }

        }

        public void CreateOrderItem(OrderItems model)
        {
            model.tOrderItem = new OrderItem();

            try
            {
                model.tOrderItem.OrderId = model.oiOrderId;
                model.tOrderItem.Name = model.oiName;
                model.tOrderItem.Quantity = model.oiQuantity;
                model.tOrderItem.Unit = model.oiUnit;
                dbContext.Repository<OrderItem>().Create(model.tOrderItem);
                dbContext.Save();
            }
            catch (IOException e)
            {

            }
        }

        public ActionResult SaveChanges(OrderItems model, int id)
        {
            try
            {
                model.currentOrderItem.OrderId = model.orderId;
                model.currentOrderItem.Name = model.oiName;
                model.currentOrderItem.Quantity = model.oiQuantity;
                model.currentOrderItem.Unit = model.oiUnit;
                dbContext.Repository<OrderItem>().Update(model.tOrderItem);
                dbContext.Save();
            }
            catch (IOException e)
            {

            }
            return RedirectToAction("Index1");
        }

        public ActionResult DeleteOrderItem(OrderItems model, int id)
        {
            model.tOrderItem = new OrderItem();


            try
            {
                model.tOrderItem.OrderId = null;
                model.tOrderItem.Name = null;
                model.tOrderItem.Quantity = null;
                model.tOrderItem.Unit = null;
                dbContext.Repository<OrderItem>().Delete(model.tOrderItem);
                dbContext.Save();
            }
            catch (IOException e)
            {

            }
            return RedirectToAction("Index1");
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}