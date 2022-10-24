using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.EF;
using DataModel.Dao;
using PagedList;

namespace DataModel.Dao
{
   public class ProductCategoryDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();

        //public IEnumerable<Product> GetProduct(long id, int page, int pageSize)
        //{
        //    return db.Products.Where(n => n.CategoryID == id).OrderBy(n => n.ID).ToPagedList(page, pageSize);
        //}
        public IEnumerable<ProductCategory> GetProductCategory(string SearchString,int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategories;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(n => n.Name.Contains(SearchString));
            }
            return model.OrderByDescending(n => n.CreatedDate).ToPagedList(page, pageSize);
            
        }
        public void Create(ProductCategory productCategoryDTO, string SessionUsername)
        {
            var a = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime dt = DateTime.ParseExact(a, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            productCategoryDTO.MetaTitle = ReplaceName.RemoveVietnameseTone(productCategoryDTO.Name);
            productCategoryDTO.SeoTitle = ReplaceName.RemoveVietnameseTone(productCategoryDTO.Name);
            productCategoryDTO.CreatedDate = dt;
            productCategoryDTO.CreatedBy = SessionUsername;
            db.ProductCategories.Add(productCategoryDTO);
            db.SaveChanges();
        }
        public void Edit(ProductCategory productCategoryDTO, string SessionUsername)
        {
            var a = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime dt = DateTime.ParseExact(a, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            productCategoryDTO.ModifiedBy = SessionUsername;
            productCategoryDTO.ModifiedDate = dt;
            productCategoryDTO.MetaTitle = ReplaceName.RemoveVietnameseTone(productCategoryDTO.Name);
            productCategoryDTO.SeoTitle = ReplaceName.RemoveVietnameseTone(productCategoryDTO.Name);
            db.Entry(productCategoryDTO).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(long id)
        {
            var result = db.ProductCategories.FirstOrDefault(n => n.ID == id);
            db.ProductCategories.Remove(result);
            db.SaveChanges();
        }
        
    }
}
