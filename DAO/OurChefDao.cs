using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.DAO
{
    public class OurChefDao
    {
        Model5 db = null;
        public OurChefDao()
        {
            db = new Model5();
        }

        public OurChefs GetByID(long id)
        {
            return db.OurChefs.Find(id);
        }
        public long Insert(OurChefs entity)
        {
            db.OurChefs.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(OurChefs entity)
        {
            try
            {
                var ourChef = db.OurChefs.Find(entity.ID);
                ourChef.Name = entity.Name;
                ourChef.CreateDate = DateTime.Now;
                ourChef.Address = entity.Address;
                ourChef.Descripton = entity.Descripton;
                ourChef.Email = entity.Email;
                ourChef.Image = entity.Image;
                ourChef.LinkFb = entity.LinkFb;
                ourChef.LinkInstagam = entity.LinkInstagam;
                ourChef.office = entity.office;
                ourChef.Phone = entity.Phone;
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
                var ourChefs = db.OurChefs.Find(id);
                db.OurChefs.Remove(ourChefs);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public OurChefs ViewDetail(long id)
        {
            return db.OurChefs.Find(id);
        }
        public IEnumerable<OurChefs> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<OurChefs> model = db.OurChefs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public List<OurChefs> ListOurChef(int top)
        {
            return db.OurChefs.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public List<OurChefs> ListOurChefT(int top)
        {
            return db.OurChefs.OrderByDescending(x => x.ID).Take(top).ToList();
        }
        public List<OurChefs> ListOurChefA(int top)
        {
            return db.OurChefs.Where(x=>x.office !=null).Take(top).ToList();
        }


    }
}