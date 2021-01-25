using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.DAO
{
    public class emailDao
    {
        Model8 db = null;
        public emailDao()
        {
            db = new Model8();
        }
        public Email GetByID(int id)
        {
            return db.Email.Find(id);
        }
        public long InsertFeddBack(Email fb)
        {
            db.Email.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
        public Email ViewDetail(long id)
        {
            return db.Email.Find(id);
        }
        public long Insert(Email entity)
        {
            db.Email.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Email entity)
        {
            try
            {
                var email = db.Email.Find(entity.ID);
                email.Email1 = entity.Email1;
                email.CreateDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<Email> ListAllPaging()
        {
            IQueryable<Email> model = db.Email;

            return model.OrderByDescending(x => x.CreateDate);
        }
        public bool Delete(int id)
        {
            try
            {
                var email = db.Email.Find(id);
                db.Email.Remove(email);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Email> ListEmail(int top)
        {
            return db.Email.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
    }
}