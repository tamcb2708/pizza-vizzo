namespace webMVC1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductViews
    {
        public long ID { get; set; }

        public string Images { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public string CateName { get; set; }

        public string CateMetaTitle { get; set; }

        public string MetaTitle { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
