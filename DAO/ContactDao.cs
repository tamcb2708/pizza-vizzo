using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.DAO
{
    public class ContactDao
    {
        Model2 db = null;
        public ContactDao()
        {
            db = new Model2();
        }
        public Contact GetByID(long id)
        {
            return db.Contact.Find(id);
        }
        public long Insert(Contact entity)
        {
            db.Contact.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Contact entity)
        {
            try
            {
                var contact = db.Contact.Find(entity.ID);
                contact.content = entity.content;
                contact.status = entity.status;

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
                var contact = db.Contact.Find(id);
                db.Contact.Remove(contact);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Contact ViewDetail(long id)
        {
            return db.Contact.Find(id);
        }
        public IEnumerable<Contact> ListAllPaging()
        {
            IQueryable<Contact> model = db.Contact;

            return model.OrderByDescending(x => x.ID);
        }
        public bool ChangeStatus(long id)
        {
            var contact = db.Contact.Find(id);
            contact.status = !contact.status;
            db.SaveChanges();
            return !contact.status;
        }

        public Contact GetActiveContact()
        {
            return db.Contact.Single(x => x.status == true);
        }
        public long InsertFeddBack(FeedBack fb)
        {
            db.FeedBack.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
    }
}