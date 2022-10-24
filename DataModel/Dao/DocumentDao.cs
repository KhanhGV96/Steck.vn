using DataModel.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Dao
{
    public class DocumentDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();
        public IEnumerable<Document> GetListNew(string SearchString, int page, int pageSize)
        {
            IQueryable<Document> model = db.Documents;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(n => n.Name.Contains(SearchString));
            }

            return model.OrderByDescending(n => n.CreatedDate).ToPagedList(page, pageSize);
        }
        public Document Detail(long id)
        {
            return db.Documents.FirstOrDefault(n => n.ID == id);
        }
        public void Create(Document document, string sessionName)
        {
            //var date = DateTime.Now.ToString("dd/MM/yyyy");
            //DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //document.MetaTitle = ReplaceName.RemoveVietnameseTone(document.Name);
            //document.MetaDescriptions = ReplaceName.RemoveVietnameseTone(document.Description);
            //document.CreatedDate = dt;
            //document.CreatedBy = sessionName;
            //document.Status = true;
            //db.Documents.Add(document);
            //db.SaveChanges();
            document.MetaTitle = ReplaceName.RemoveVietnameseTone(document.Name);
            document.CreatedDate = DateTime.Now;
            document.CreatedBy = sessionName;
            db.Documents.Add(document);
            db.SaveChanges();


        }
        public void Edit(Document document, string sessionName)
        {
            //var date = DateTime.Now.ToString("dd/MM/yyyy");
            //DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //document.MetaTitle = ReplaceName.RemoveVietnameseTone(document.Name);
            //document.ModifiedDate = dt;
            //document.ModifiedBy = sessionName;
            //document.MetaDescriptions = ReplaceName.RemoveVietnameseTone(document.Description);
            //db.Entry(document).State = EntityState.Modified;
            //db.SaveChanges();
            document.CreatedDate = DateTime.Now;
            document.CreatedBy = sessionName;
            db.Entry(document).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(long id)
        {
            var document = db.Documents.FirstOrDefault(n => n.ID == id);
            db.Documents.Remove(document);
            db.SaveChanges();
        }

    }
}
