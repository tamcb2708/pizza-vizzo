using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;
namespace webMVC1.DAO
{
    public class DetailDao
    {
        database db = null;
        public DetailDao()
        {
            db = new database();
        }
        public List<Detail> ListAll()
        {
            return db.Detail.Where(x => x.Status == true).OrderBy(x => x.ID).ToList();

        }
        public Detail GetByID(long id)
        {
            return db.Detail.Find(id);
        }
        public long Insert(Detail entity)
        {
            db.Detail.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Detail entity)
        {
            try
            {
                var detail = db.Detail.Find(entity.ID);
                detail.Name = entity.Name;
                detail.CreateDate = DateTime.Now;
                detail.Status = entity.Status;
                detail.CreateBy = entity.CreateBy;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                var detail = db.Detail.Find(id);
                db.Detail.Remove(detail);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Detail ViewDetail(int id)
        {
            return db.Detail.Find(id);
        }
        public IEnumerable<Detail> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Detail> model = db.Detail;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public bool ChangeStatus(long id)
        {
            var detail = db.Detail.Find(id);
            detail.Status = !detail.Status;
            db.SaveChanges();
            return !detail.Status;
        }
    }
}