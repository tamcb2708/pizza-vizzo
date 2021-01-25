using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;
using System.Threading.Tasks;
using System.Collections;

namespace webMVC1.DAO
{
    public class CategoryDao
    {
        Model1 db = null;
        public CategoryDao()
        {
            db = new Model1();
        }
        public Categorys GetByID(long id)
        {
            return db.Categorys.Find(id);
        }
        public long Insert(Categorys entity)
        {
            db.Categorys.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Categorys entity)
        {
            try
            {
                var categorys = db.Categorys.Find(entity.ID);
                categorys.Name = entity.Name;
                categorys.CreateDate = DateTime.Now;
                categorys.MetaTitle = entity.MetaTitle;
                categorys.MetaDescriptions = entity.MetaDescriptions;
                categorys.MetaKeywords = entity.MetaKeywords;
                categorys.MetaTitle = entity.MetaTitle;
                categorys.Status = entity.Status;
                categorys.SeoTitle = entity.SeoTitle;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public IEnumerable<Categorys> ListAllPaging()
        {
            IQueryable<Categorys> model = db.Categorys;
            
            return model.OrderByDescending(x => x.CreateDate);
        }
        public bool Delete(int id)
        {
            try
            {
                var Categorys = db.Categorys.Find(id);
                db.Categorys.Remove(Categorys);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Categorys ViewDetail(long id)
        {
            return db.Categorys.Find(id);
        }
        public List<Categorys> ListAll()
        {
            return db.Categorys.Where(x => x.Status == true).OrderBy(x => x.ID).ToList();
        }
        public Categorys ViewDetails(long id)
        {
            return db.Categorys.Find(id);
        }
    }
}