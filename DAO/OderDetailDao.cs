using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.DAO
{
    public class OderDetailDao
    {
        Model6 db = null;
        public OderDetailDao()
        {
            db = new Model6();
        }
        public bool Insert(OderDetail detail)
        {
            try
            {
                db.OderDetail.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public IEnumerable<OderDetail> ListAllPaging( int page, int pageSize)
        {
            IQueryable<OderDetail> model = db.OderDetail;
            return model.OrderByDescending(x => x.ProductID).ToPagedList(page, pageSize);
        }
        public List<OderDetail> ListOrderDetail(int top)
        {
            return db.OderDetail.OrderByDescending(x => x.OrderID).Take(top).ToList();
        }
    }
}