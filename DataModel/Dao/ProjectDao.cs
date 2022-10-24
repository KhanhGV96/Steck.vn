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
    public class ProjectDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();
        public IEnumerable<Project> GetListNew(string SearchString, int page, int pageSize)
        {
            IQueryable<Project> model = db.Projects;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(n => n.Name.Contains(SearchString));
            }

            return model.OrderByDescending(n => n.CreatedDate).ToPagedList(page, pageSize);
        }
        public Project Detail(long id)
        {
            return db.Projects.FirstOrDefault(n => n.ID == id);
        }
        public void Create(Project project, string sessionName)
        {
            //var date = DateTime.Now.ToString("dd/MM/yyyy");
            //DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //project.MetaTitle = ReplaceName.RemoveVietnameseTone(project.Name);
            //project.MetaDescriptions = ReplaceName.RemoveVietnameseTone(project.Description);
            //project.CreatedDate = dt;
            //project.CreatedBy = sessionName;
            //project.Status = true;
            //db.Projects.Add(project);
            //db.SaveChanges();


            project.MetaTitle = ReplaceName.RemoveVietnameseTone(project.Name);
            //project.SeoTitle = ReplaceName.RemoveVietnameseTone(project.Name);

            project.CreatedBy = sessionName;
            db.Projects.Add(project);
            db.SaveChanges();
        }
        public void Edit(Project project, string sessionName)
        {
            //var date = DateTime.Now.ToString("dd/MM/yyyy");
            //DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //project.MetaTitle = ReplaceName.RemoveVietnameseTone(project.Name);
            //project.ModifiedDate = dt;
            //project.ModifiedBy = sessionName;
            //project.MetaDescriptions = ReplaceName.RemoveVietnameseTone(project.Description);
            //db.Entry(project).State = EntityState.Modified;
            //db.SaveChanges();


            project.ModifiedDate = DateTime.Now;
            project.ModifiedBy = sessionName;
            db.Entry(project).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(long id)
        {
            var project = db.Projects.FirstOrDefault(n => n.ID == id);
            db.Projects.Remove(project);
            db.SaveChanges();
        }
    }
}
