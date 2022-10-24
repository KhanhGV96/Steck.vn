using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.EF;

namespace DataModel.Dao
{
    public class OrderDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();

        public List<Order> GetDataOrder()
        {
            List<Order> lstOrder = db.Orders.OrderBy(n=>n.Status).ThenByDescending(n=>n.CreatedDate).ToList();
            return lstOrder;
        }

        public List<Order> GetDataOrderActive()
        {
            List<Order> lstOrder = db.Orders.Where(n => n.Status == 1).ToList();
            return lstOrder;
        }

        public void CreateOder(long cusID, string name, string mobile, string adr, string email, string note)
        {
            Order od = new Order();
            od.CustomerID = cusID;
            od.ShipName = name;
            od.ShipMobile = mobile;
            od.ShipAddress = adr;
            od.ShipEmail = email;
            od.CreatedDate = DateTime.Now;
            od.Status = 0;
            od.Note = note;
            db.Orders.Add(od);
            db.SaveChanges();
        }

        public long GetOrderDetailsID()
        {
            long id = db.Orders.Max(n => n.ID);
            return id;
        }

        public void CreateOrderDetail(long orderID, long proID, int quantity)
        {
            ProductDao pdao = new ProductDao();
            Product product = pdao.GetProductByID(proID);
            decimal price = product.PromotionPrice != 0 ? (decimal)product.PromotionPrice : (decimal)product.Price;
            OrderDetail odDetail = new OrderDetail();
            odDetail.OrderID = orderID;
            odDetail.ProductID = proID;
            odDetail.Quantity = quantity;
            odDetail.Price = price;
            db.OrderDetails.Add(odDetail);
            db.SaveChanges();
        }

        //Sửa status = 1
        public void ActiveOrder(long orderID)
        {
            Order od = new Order();
            od = db.Orders.Where(n => n.ID == orderID).FirstOrDefault();
            od.Status = 1;
            db.Entry(od).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
