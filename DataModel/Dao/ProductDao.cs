using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.EF;

namespace DataModel.Dao
{

    public class ProductDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();
        public Product GetProductByID(long id)
        {
            var item = db.Products.FirstOrDefault(n => n.ID == id);
            return item;
        }
        public void Create(Product productDTO, string sessionUser)
        {

            DateTime dt = DateTime.Now;
            productDTO.PromotionPrice = 0;
            long? id = db.Products.Max(n => n.ID);
            if (id == null)
            {
                id = 0;
            }
            long? max = id + 1;  
            productDTO.Code = "SP00" + max;
            productDTO.MetaTitle = ReplaceName.RemoveVietnameseTone(productDTO.Name);
            productDTO.CreatedDate = dt;
            productDTO.CreatedBy = sessionUser;
            productDTO.MetaDescriptions = ReplaceName.RemoveVietnameseTone(productDTO.Description);
            productDTO.Status = true;
            db.Products.Add(productDTO);
            db.SaveChanges();
        }
        public void Edit(Product productDTO,string sessionUser)
        {
            //Product pd = GetProductByID(productDTO.ID);
            //productDTO.Code = pd.Code;
            productDTO.MetaTitle = ReplaceName.RemoveVietnameseTone(productDTO.Name);
            productDTO.ModifiedDate = DateTime.Now;
            productDTO.ModifiedBy = sessionUser;
            productDTO.MetaDescriptions = ReplaceName.RemoveVietnameseTone(productDTO.Description);
            db.Entry(productDTO).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(long id)
        {
            var Product = db.Products.FirstOrDefault(n => n.ID == id);
            db.Products.Remove(Product);
            db.SaveChanges();
        }
        public long GetQuantity(long id, long ColorID)
        {
            var model = (from pro in db.ProductColors
                         join color in db.Colors on pro.ColorID equals color.ID
                         where pro.ProductID == id && color.ID == ColorID
                         select pro).FirstOrDefault();
            return model.Quantity;
        }
    }
}
