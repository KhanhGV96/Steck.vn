using DataModel.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Dao
{
    public class ContactDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();
        public IEnumerable<Contact> Contact(string SearchString, int page, int pageSize)
        {
            IQueryable<Contact> model = db.Contacts;
            if (!string.IsNullOrEmpty(SearchString))
            {
                model = model.Where(n => n.UserName.Contains(SearchString));
            }
            return model.OrderByDescending(n => n.CreatedDate).ToPagedList(page, pageSize);
        }
        public void Create(Contact contactDTO)
        {
            contactDTO.CreatedDate = DateTime.Now;
            db.Contacts.Add(contactDTO);
            db.SaveChanges();
        }
    }
}
