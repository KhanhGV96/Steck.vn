using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.EF;
using PagedList;

namespace DataModel.Dao
{
    public class SlideDao
    {
        OnlineShopDataContext db = new OnlineShopDataContext();
        public IEnumerable<Slide> GetSlides(string SeachString,int page, int pagesize)
        {
            IEnumerable<Slide> model = db.Slides;
            if (!(string.IsNullOrEmpty(SeachString)))
            {
                model = model.Where(n => n.Description.Contains(SeachString));
            }
            model = model.OrderByDescending(n =>n.CreatedDate).ToPagedList(page, pagesize);
            return model;
        }
        public void Delete(long id)
        {
            var slideImg = db.Slides.FirstOrDefault(n => n.ID == id);
            db.Slides.Remove(slideImg);
            db.SaveChanges();
        }
    }
}
