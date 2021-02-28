using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webMVC1.EF;

namespace webMVC1.Models
{
    [Serializable]
    public class CartItem
    {
        public Product Pro{ set; get; }
        public int Quantity { set; get; }
        public string Size { set; get; }

    }
}