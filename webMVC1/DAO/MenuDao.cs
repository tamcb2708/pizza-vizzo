using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.DAO
{
    public class MenuDao
    {
        database db = null;
        public MenuDao()
        {
            db = new database();
        }
        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menu.Where(x => x.TypeID == groupId && x.Status==true).ToList();
        }
        public Menu GetByID(long id)
        {
            return db.Menu.Find(id);
        }
        public long Insert(Menu entity)
        {
            db.Menu.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Menu entity)
        {
            try
            {
                var menu = db.Menu.Find(entity.ID);
                menu.Link = entity.Link;
                menu.Status = entity.Status;
                menu.Target = entity.Target;
                menu.DisPlayOrder = entity.DisPlayOrder;
                menu.Text = entity.Text;
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
                var menu = db.Menu.Find(id);
                db.Menu.Remove(menu);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Menu ViewDetail(long id)
        {
            return db.Menu.Find(id);
        }
        public IEnumerable<Menu> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Menu> model = db.Menu;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Text.Contains(searchString) || x.Text.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var menu = db.Menu.Find(id);
            menu.Status = !menu.Status;
            db.SaveChanges();
            return !menu.Status;
        }
    }
}