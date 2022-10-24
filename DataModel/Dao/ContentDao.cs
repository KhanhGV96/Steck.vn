using DataModel.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using System.Globalization;
using System.Data.Entity;

namespace DataModel.Dao
{
    
    public class ContentDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();
        public IEnumerable<Content> GetListNew(string SearchString, int page, int pageSize)
        {
            IQueryable<Content> model = db.Contents;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(n => n.Name.Contains(SearchString));
            }
            
            return model.OrderByDescending(n => n.CreatedDate).ToPagedList(page, pageSize);
        }
        public Content Detail(long id)
        { 
            return db.Contents.FirstOrDefault(n => n.ID == id);
        }
        public void Create(Content content, string sessionName)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            content.MetaTitle = ReplaceName.RemoveVietnameseTone(content.Name);
            content.MetaDescriptions = ReplaceName.RemoveVietnameseTone(content.Description);
            content.CreatedDate = dt;
            content.CreatedBy = sessionName;
            content.Status = true;
            db.Contents.Add(content);
            db.SaveChanges();
        }
        public void Edit(Content  content, string sessionName)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            content.MetaTitle = ReplaceName.RemoveVietnameseTone(content.Name);
            content.ModifiedDate = dt;
            content.ModifiedBy = sessionName;
            content.MetaDescriptions = ReplaceName.RemoveVietnameseTone(content.Description);
            db.Entry(content).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(long id)
        {
            var content = db.Contents.FirstOrDefault(n => n.ID == id);
            db.Contents.Remove(content);
            db.SaveChanges();
        }

    }
}
