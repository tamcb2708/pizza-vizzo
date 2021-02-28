using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.DAO
{
    public class AboutDao
    {
        Model2 db = null;
        public AboutDao()
        {
            db = new Model2();
        }
        public List<About> ListAbout(int top)
        {
            return db.About.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public About GetByID(long id)
        {
            return db.About.Find(id);
        }
        public long Insert(About entity)
        {
            db.About.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(About entity)
        {
            try
            {
                var about = db.About.Find(entity.ID);
                about.Name = entity.Name;
                about.CreateDate = DateTime.Now;
                about.DesCription = entity.DesCription;
                about.Detail = entity.Detail;
                about.Images = entity.Images;
                about.Quantity = entity.Quantity;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Delete(long id)
        {
            try
            {
                var about = db.About.Find(id);
                db.About.Remove(about);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public About ViewDetail(long id)
        {
            return db.About.Find(id);
        }
        public IEnumerable<About> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<About> model = db.About;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
    }
}