using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.DAO
{
    public class ContentDao
    {
        database db = null;
        public ContentDao()
        {
            db = new database();
        }
  
        public Content GetByID(long id)
        {
            return db.Content.Find(id);
        }
        public long Insert(Content entity)
        {
            db.Content.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Content entity)
        {
            try
            {
                var content = db.Content.Find(entity.ID);
                content.Name = entity.Name;
                content.CreateDate = DateTime.Now;
                content.DesCription = entity.DesCription;
                content.Detail = entity.Detail;
                content.Images = entity.Images;
                content.Quantity = entity.Quantity;
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
                var content = db.Content.Find(id);
                db.Content.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Content ViewDetail(long id)
        {
            return db.Content.Find(id);
        }
        public IEnumerable<Content> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Content> model = db.Content;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
    }
}