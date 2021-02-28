using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.DAO
{
    public class FeedBackDao
    {
        Model2 db = null;
        public FeedBackDao()
        {
            db = new Model2();
        }
        public FeedBack GetByID(long id)
        {
            return db.FeedBack.Find(id);
        }
        public long Insert(FeedBack entity)
        {
            db.FeedBack.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
    
        public IEnumerable<FeedBack> ListAllPaging()
        {
            IQueryable<FeedBack> model = db.FeedBack;

            return model.OrderByDescending(x => x.CreateDate);
        }

        public FeedBack ViewDetail(long id)
        {
            return db.FeedBack.Find(id);
        }
        public List<FeedBack> ListAll()
        {
            return db.FeedBack.Where(x => x.Content!= null).OrderBy(x => x.ID).ToList();
        }


    }
}