using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.EF;
using System.Data.SqlClient;
using PagedList;
using System.Data.Entity;
using System.Globalization;

namespace DataModel.Dao
{
    public class UserDao
    {
        OnlineShopDataContext db = null;


        public UserDao()
        {
            db = new OnlineShopDataContext();
        }

        public User GetUserByUsername(string username)
        {
            var user = db.Users.FirstOrDefault(n => n.UserName == username);
            return user;
        }

        public long Insert(User model, string sessionUserName)
        {
            if (db.Users.Where(n => n.UserName == model.UserName).Count() > 0)
            {
                return -1;
            }
            else
            {
                //var datetime = DateTime.Now.ToString("dd/MM/yyyy");
                //DateTime date = DateTime.ParseExact(datetime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = sessionUserName;
                model.Password = ReplaceName.GetMD5(model.Password);
                if (model.GroupID == null)
                {
                    model.GroupID = "MEMBER";
                }
                model.Status = true;
                db.Users.Add(model);
                db.SaveChanges();
                return model.ID;
            }
        }
        public long Edit(User UserDTO)
        {
            db.Entry(UserDTO).State = EntityState.Modified;
            db.SaveChanges();
            return UserDTO.ID;
        }
        public void Delete(long id)
        {
            var result = db.Users.FirstOrDefault(n => n.ID == id);
            db.Users.Remove(result);
            db.SaveChanges();
        }

        public IEnumerable<User> GetListUser(string SearchString,int page, int pageSize)
        {
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(x => x.UserName.Contains(SearchString) || x.Name.Contains(SearchString));
            }

            return model.OrderByDescending(n => n.CreatedDate).ToPagedList(page, pageSize);
        }
        public User GetById(string username)
        {
            return db.Users.FirstOrDefault(x => x.UserName == username);
        }
        public int Login(string username, string password)
        {
            var Result = db.Users.FirstOrDefault(n => n.UserName == username);
            if(Result == null)
            {
                return 0;
            }
            else
            {
                if(Result.Status == false)
                {
                    return -1;
                }
                else
                {
                   if(Result.Password == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
        public bool ChangeStatus(long id)
        {
            var User = db.Users.FirstOrDefault(n => n.ID == id);
            User.Status = !User.Status;
            db.SaveChanges();
            return User.Status;
        }
    }
}
