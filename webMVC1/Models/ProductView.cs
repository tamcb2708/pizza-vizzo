using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webMVC1.Models
{
    public class ProductView
    {
        public long ID { set; get; }
        public string  Images { set; get; }
        public string Name { set; get; }
        public decimal? Price { set; get; }
        public string CateName { set; get; }
        public string CateMetaTitle { set; get; }
        public string MetaTitle { set; get; }
        public DateTime? CreateDate { set; get; }
    }
}