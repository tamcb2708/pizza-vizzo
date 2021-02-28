using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;
using System.Threading.Tasks;
using System.IO;
using webMVC1.Models;

namespace webMVC1.DAO
{
    public class ProductDao
    {
        Model1 db = null;
        public ProductDao()
        {
            db = new Model1();
        }
        public Product ViewDetail(long id)
        {
            return db.Product.Find(id);
        }
        public Product GetByID(long id)
        {
            return db.Product.Find(id);
        }
        public long Insert(Product entity)
        {
            db.Product.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Product entity)
        {
            try
            {
                var product = db.Product.Find(entity.ID);
                product.Name = entity.Name;
                product.DesCription = entity.DesCription;
                product.Images = entity.Images;
                product.MetaDescriptions = entity.MetaDescriptions;
                product.MetaKeywords = entity.MetaKeywords;
                product.MetaTitle = entity.MetaTitle;
                product.Tophot = entity.Tophot;
                product.Price = entity.Price;
                product.CreateDate = DateTime.Now;
                product.Quantity = entity.Quantity;
                product.CategoryID = entity.CategoryID;
                product.PromotionPrice = entity.PromotionPrice;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Product;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }

        public List<Product> ListPizza(int top)
        {
            return db.Product.Where(x=>x.Status==false).Take(top).ToList();
        }
        public List<Product> ListPopularMenu(int top)
        {
            return db.Product.Where(x => x.Code!=null && x.Status==true).OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }
        public List<Product> ListFooter(int top)
        {
            return db.Product.OrderByDescending(x => x.MetaKeywords!=null && x.Status==true).Take(top).ToList();
        }
        public List<Product> ListFooterT(int top)
        {
            return db.Product.OrderByDescending(x => x.Warranty).Take(top).ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var Product = db.Product.Find(id);
                db.Product.Remove(Product);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// get list product by ccategory
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        
        public List<Product> ListByCategoryID(long categoryID,ref int totalRecord,int pageIndex=1,int pageSize=8)
        {
            totalRecord = db.Product.Where(x => x.CategoryID == categoryID).Count();
            var model= db.Product.Where(x => x.CategoryID == categoryID).OrderByDescending(x=>x.CreateDate).Skip((pageSize-1)*pageIndex).Take(pageSize).ToList();
            return model;
        }
        public List<Product> ListAllT(int top)
        {
            return db.Product.Where(x => x.Code==null && x.Status==true).OrderBy(x => x.Price).ToList();
        }
        public List<Product> ListAll()
        {
            return db.Product.Where(x => x.Status == true).OrderBy(x => x.Price).ToList();
        }
        public List<Categorys> ListCategory(int top)
        {
            return db.Categorys.Where(x => x.Status == true).OrderByDescending(x => x.ID).ToList();
        }
        public List<string> ListName(string keyword)
        {
            return db.Product.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }
        public List<ProductView> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 8)
        {
            totalRecord = db.Product.Where(x => x.Name.Contains(keyword)).Count();
            var model = (from a in db.Product
                         join b in db.Categorys
                         on a.CategoryID equals b.ID
                         where a.Name.Contains(keyword)
                         select new
                         {
                             CateMetaTitle = b.MetaTitle,
                             CateName = b.Name,
                             CreateDate = a.CreateDate,
                             ID = a.ID,
                             Images = a.Images,
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Price = a.Price

                         }).AsEnumerable().Select(x => new ProductView()
                         {
                             CateMetaTitle = x.MetaTitle,
                             CateName = x.Name,
                             CreateDate = x.CreateDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreateDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }


    }
}