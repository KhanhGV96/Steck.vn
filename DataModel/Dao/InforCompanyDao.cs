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
    public class InforCompanyDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();
        
        //public long Insert(User model, string sessionUserName)
        //{
        //    if (db.Users.Where(n => n.UserName == model.UserName).Count() > 0)
        //    {
        //        return -1;
        //    }
        //    else
        //    {
        //        //var datetime = DateTime.Now.ToString("dd/MM/yyyy");
        //        //DateTime date = DateTime.ParseExact(datetime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //        model.CreatedDate = DateTime.Now;
        //        model.CreatedBy = sessionUserName;
        //        model.Password = ReplaceName.GetMD5(model.Password);
        //        if (model.GroupID == null)
        //        {
        //            model.GroupID = "MEMBER";
        //        }
        //        model.Status = true;
        //        db.Users.Add(model);
        //        db.SaveChanges();
        //        return model.ID;
        //    }
        //}

        public object GetInforCompany(string SearchString, int page, int pageSize)
        {
           
            IQueryable<InforCompany> model = db.InforCompanys;
            
            return model.OrderByDescending(n => n.CreatedDate).ToPagedList(page, pageSize);
        }

        public void Edit(InforCompany inforcompanyDTO, string UserSession)
        {
            inforcompanyDTO.ModifiedDate = DateTime.Now;
            inforcompanyDTO.ModifiedBy = UserSession;
            db.Entry(inforcompanyDTO).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(long id)
        {
            var inforCompany = db.InforCompanys.FirstOrDefault(n => n.ID == id);
            db.InforCompanys.Remove(inforCompany);
            db.SaveChanges();
        }
    }
}
