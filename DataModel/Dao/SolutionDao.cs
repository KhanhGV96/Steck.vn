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
    public class SolutionDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();
        public IEnumerable<Solution> Solution(string SearchString, int page, int pageSize)
        {
            IQueryable<Solution> model = db.Solutions;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(n => n.Name.Contains(SearchString));
            }
            return model.OrderByDescending(n => n.CreatedDate).ToPagedList(page, pageSize);
        }
        public void Create(Solution solutionDTO, string UserSession)
        {

            solutionDTO.MetaTitle = ReplaceName.RemoveVietnameseTone(solutionDTO.Name);
            solutionDTO.SeoTitle = ReplaceName.RemoveVietnameseTone(solutionDTO.Name);

            solutionDTO.CreatedBy = UserSession;
            db.Solutions.Add(solutionDTO);
            db.SaveChanges();
        }
        public void Edit(Solution solutionDTO, string UserSession)
        {
            solutionDTO.ModifiedDate = DateTime.Now;
            solutionDTO.ModifiedBy = UserSession;
            db.Entry(solutionDTO).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(long id)
        {
            var solution = db.Solutions.FirstOrDefault(n => n.ID == id);
            db.Solutions.Remove(solution);
            db.SaveChanges();
        }
    }
}
