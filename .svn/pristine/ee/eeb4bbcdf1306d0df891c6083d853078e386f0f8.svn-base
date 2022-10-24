using DataModel.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Dao
{
     
    public class GroupDao
    {
        OnlineShopDataContext db = null;
        public GroupDao()
        {
            db = new OnlineShopDataContext();
        }
        public List<UserGroup> ListAll()
        {
            return db.UserGroups.ToList();
        }
        public string Insert(UserGroup groupDTO)
        {
            //var LstGR = db.UserGroups.ToList();
            //if (LstGR == null)
            //{
            //    groupDTO.ID = "GR01";
            //}
            //else
            //{
            //    var lstIntID = new List<int>();
            //    foreach (var item in LstGR)
            //    {
            //        var d = item.ID.Substring(2);
            //        var c = Convert.ToInt32(d);
            //        lstIntID.Add(c);
            //    }
            //    var MaxIntID = lstIntID.Max();
            //    groupDTO.ID = "GR" + MaxIntID;
            //}
            db.UserGroups.Add(groupDTO);
            db.SaveChanges();
            return groupDTO.ID;

        }
        public string Update(UserGroup groupDTO)
        {
            db.Entry(groupDTO).State = EntityState.Modified;
            db.SaveChanges();
            return groupDTO.ID;
        }
        public void Delete(string id)
        {
            var result = db.UserGroups.FirstOrDefault(n => n.ID == id);
            db.UserGroups.Remove(result);
            db.SaveChanges();
        }
    }
   
}
