using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;
namespace webMVC1.DAO
{
    public class OderDao
    {
        Model6 db = null;
        public OderDao()
        {
            db = new Model6();
        }
        public long Insert(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public IEnumerable<Order> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Order> model = db.Order;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.ShipName.Contains(searchString) || x.ShipEmail.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public List<Order> ListOrder(int top)
        {
            return db.Order.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
    }
}