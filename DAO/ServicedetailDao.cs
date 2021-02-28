using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.DAO
{
    public class ServicedetailDao
    {
        Model3 db = null;
        public ServicedetailDao()
        {
            db = new Model3();
        }
        public List<CategoryDetail> ListAll()
        {
            return db.CategoryDetail.Where(x => x.Status == true).OrderBy(x => x.ID).ToList();
        }
        public List<CategoryDetail> ListA(int top)
        {
            return db.CategoryDetail.OrderBy(x => x.ID).Take(top).ToList();
        }
    }
}