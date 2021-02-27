using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.DAO
{
    public class CategoryDetailDao
    {
        database db = null;
        public CategoryDetailDao()
        {
            db = new database();
        }
        public CategoryDetail GetByID(long id)
        {
            return db.CategoryDetail.Find(id);
        }
        public long Insert(CategoryDetail entity)
        {
            db.CategoryDetail.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(CategoryDetail entity)
        {
            try
            {
                var CategoryDetails = db.CategoryDetail.Find(entity.ID);
                CategoryDetails.Name = entity.Name;
                CategoryDetails.CreateDate = DateTime.Now;
                CategoryDetails.MetaTitle = entity.MetaTitle;
                CategoryDetails.answer = entity.answer;
                CategoryDetails.DesCription = entity.DesCription;
                CategoryDetails.MetaTitle = entity.MetaTitle;
                CategoryDetails.Status = entity.Status;
                CategoryDetails.Question = entity.Question;
                CategoryDetails.Images = entity.Images;
                CategoryDetails.DetailID = entity.DetailID;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public IEnumerable<CategoryDetail> ListAllPaging()
        {
            IQueryable<CategoryDetail> model = db.CategoryDetail;

            return model.OrderByDescending(x => x.CreateDate);
        }
        public bool Delete(int id)
        {
            try
            {
                var CategoryDetails = db.CategoryDetail.Find(id);
                db.CategoryDetail.Remove(CategoryDetails);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public CategoryDetail ViewDetail(long id)
        {
            return db.CategoryDetail.Find(id);
        }
        public List<CategoryDetail> ListAll()
        {
            return db.CategoryDetail.Where(x => x.Status == true).OrderBy(x => x.ID).ToList();
        }

    }
}