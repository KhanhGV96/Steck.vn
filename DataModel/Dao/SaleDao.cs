using DataModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Globalization;
using System.Data.Entity;
using DataModel.Dao;
using System.Data;

namespace DataModel.Dao
{

    public class SaleDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();
        public IEnumerable<Sale> GetSales(string SeachString, int page, int pagesize)
        {
            //var a = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime dt = DateTime.Now;
            IQueryable<Sale> sales = db.Sales;
            var sales2 = sales.Where(n => n.EndDate < dt);
            var idSale = sales2.Select(n => n.ID).ToList();
            foreach (var item in idSale)
            {
                foreach (var itemPro in db.Products.Where(n => n.SaleID == item).ToList())
                {
                    itemPro.PromotionPrice = 0;
                    db.Entry(itemPro).State = EntityState.Modified;
                    db.SaveChanges();
                }
                var saleOb = db.Sales.Where(n => n.ID == item).FirstOrDefault();
                saleOb.Status = false;
                db.Entry(saleOb).State = EntityState.Modified;
                db.SaveChanges();
            }
            if (!string.IsNullOrEmpty(SeachString))
            {

                sales = sales.Where(n => n.Name.Contains(SeachString));

            }
            return sales.OrderByDescending(n => n.CreatedDate).ToPagedList(page, pagesize);
        }
        public Sale Details(long id)
        {
            return db.Sales.FirstOrDefault(n => n.ID == id);
        }
        public void Create(Sale saleDTO, string UserSession)
        {
            //var a = DateTime.Now.ToString("dd/MM/yyyy");
            //DateTime dt = DateTime.ParseExact(a, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            saleDTO.MetaTitle = ReplaceName.RemoveVietnameseTone(saleDTO.Name);
            saleDTO.CreatedDate = DateTime.Now;
            saleDTO.CreatedBy = UserSession;
            saleDTO.Status = true;
            db.Sales.Add(saleDTO);
            db.SaveChanges();
        }
        public void Edit(Sale saleDTO, string SesionUser)
        {
            var a = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime dt = DateTime.ParseExact(a, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            saleDTO.MetaTitle = ReplaceName.RemoveVietnameseTone(saleDTO.Name);
            saleDTO.CreatedBy = SesionUser;
            saleDTO.CreatedDate = dt;
            db.Entry(saleDTO).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
