using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using DataModel.EF;
using DataModel.Dao;
using System.Globalization;
using System.Data.Entity;

namespace DataModel.Dao
{
    
    public class CategoryDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();
        public IEnumerable<Category> GetCategory(string SearchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(n => n.Name.Contains(SearchString));
            }
            return model.OrderByDescending(n => n.CreatedDate).ToPagedList(page, pageSize);
        }
        public void Create(Category categoryDTO, string UserSession)
        {
            DateTime dt = DateTime.Now;
            categoryDTO.MetaTitle = ReplaceName.RemoveVietnameseTone(categoryDTO.Name);
            categoryDTO.SeoTitle = ReplaceName.RemoveVietnameseTone(categoryDTO.Name);
            categoryDTO.CreatedDate = dt;
            categoryDTO.CreatedBy = UserSession;
            db.Categories.Add(categoryDTO);
            db.SaveChanges();
        }
        public void Edit(Category categoryDTO, string UserSession)
        {
            categoryDTO.ModifiedDate = DateTime.Now;
            categoryDTO.ModifiedBy = UserSession;
            db.Entry(categoryDTO).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(long id)
        {
            var category = db.Categories.FirstOrDefault(n => n.ID == id);
            db.Categories.Remove(category);
            db.SaveChanges();
        }
    }
}
