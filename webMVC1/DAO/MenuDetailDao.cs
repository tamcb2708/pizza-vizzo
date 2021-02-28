using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.DAO
{
    public class MenuDetailDao
    {
        database db = null;
        public MenuDetailDao()
        {
            db = new database();
        }
        public About GetByID(long id)
        {
            return db.About.Find(id);
        }
        public long Insert(MenuType entity)
        {
            db.MenuType.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(MenuType entity)
        {
            try
            {
                var menuType = db.MenuType.Find(entity.ID);
                menuType.Name = entity.Name;
        
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
                var menuType = db.MenuType.Find(id);
                db.MenuType.Remove(menuType);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public MenuType ViewDetail(long id)
        {
            return db.MenuType.Find(id);
        }
        public IEnumerable<MenuType> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<MenuType> model = db.MenuType;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
    }
}