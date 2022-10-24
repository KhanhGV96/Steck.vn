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
    public class IntroduceDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();
        public IEnumerable<Introduce> Introduce(string SearchString, int page, int pageSize)
        {
            IQueryable<Introduce> model = db.Introduces;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(n => n.Name.Contains(SearchString));
            }
            return model.OrderByDescending(n => n.CreatedDate).ToPagedList(page, pageSize);
        }
        public void Create(Introduce introduceDTO, string UserSession)
        {
            
            introduceDTO.MetaTitle = ReplaceName.RemoveVietnameseTone(introduceDTO.Name);
            introduceDTO.SeoTitle = ReplaceName.RemoveVietnameseTone(introduceDTO.Name);
            
            introduceDTO.CreatedBy = UserSession;
            db.Introduces.Add(introduceDTO);
            db.SaveChanges();
        }
        public void Edit(Introduce introduceDTO, string UserSession)
        {
            introduceDTO.ModifiedDate = DateTime.Now;
            introduceDTO.ModifiedBy = UserSession;
            db.Entry(introduceDTO).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(long id)
        {
            var introduce = db.Introduces.FirstOrDefault(n => n.ID == id);
            db.Introduces.Remove(introduce);
            db.SaveChanges();
        }
    }
    
}
