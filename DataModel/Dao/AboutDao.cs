using DataModel.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Dao
{
    public class AboutDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();
        public IEnumerable<About> About(string SearchString, int page, int pageSize)
        {
            IQueryable<About> model = db.Abouts;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(n => n.Name.Contains(SearchString));
            }
            return model.OrderByDescending(n => n.CreatedDate).ToPagedList(page, pageSize);
        }
        public void Create(About aboutDTO, string UserSession)
        {

            aboutDTO.MetaTitle = ReplaceName.RemoveVietnameseTone(aboutDTO.Name);
            

            aboutDTO.CreatedBy = UserSession;
            db.Abouts.Add(aboutDTO);
            db.SaveChanges();
        }
        public void Edit(About aboutDTO, string UserSession)
        {
            aboutDTO.ModifiedDate = DateTime.Now;
            aboutDTO.ModifiedBy = UserSession;
            db.Entry(aboutDTO).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(long id)
        {
            var about = db.Abouts.FirstOrDefault(n => n.ID == id);
            db.Abouts.Remove(about);
            db.SaveChanges();
        }
    }
}
