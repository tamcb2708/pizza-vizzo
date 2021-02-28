using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.DAO
{
    public class FAQDao
    {
        database db = null;
        public FAQDao()
        {
            db = new database();
        }
        public List<questionandanswer> ListAll()
        {
            return db.questionandanswer.OrderByDescending(x=>x.CreateDate).ToList();
        }
        public long InsertFeddBack(questionandanswer fb)
        {
            db.questionandanswer.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
        public List<questionandanswer> GetActiveContact()
        {
            return db.questionandanswer.Where(x => x.status == true).ToList();
        }
        public bool ChangeStatus(long id)
        {
            var contact = db.questionandanswer.Find(id);
            contact.status = !contact.status;
            db.SaveChanges();
            return !contact.status;
        }
        public questionandanswer GetByID(long id)
        {
            return db.questionandanswer.Find(id);
        }
        public long Insert(questionandanswer entity)
        {
            db.questionandanswer.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(questionandanswer entity)
        {
            try
            {
                var faq = db.questionandanswer.Find(entity.ID);
                faq.Name = entity.Name;
                faq.Phone = entity.Phone;
                faq.Question = entity.Question;
                faq.Subject = entity.Subject;
                faq.Answer = entity.Answer;
                faq.status = entity.status;

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
                var faq = db.questionandanswer.Find(id);
                db.questionandanswer.Remove(faq);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public questionandanswer ViewDetail(long id)
        {
            return db.questionandanswer.Find(id);
        }
        public IEnumerable<questionandanswer> ListAllPaging()
        {
            IQueryable<questionandanswer> model = db.questionandanswer;

            return model.OrderByDescending(x => x.ID);
        }

    }
}