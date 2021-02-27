namespace webMVC1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string DesCription { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public long? CategoryID { get; set; }

        [StringLength(50)]
        public string MetaTitle { get; set; }

        [Column(TypeName = "text")]
        public string Detail { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        public int? Warranty { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [StringLength(50)]
        public string ModifiedDate { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public DateTime? Tophot { get; set; }

        public decimal? PromotionPrice { get; set; }

        public virtual Categorys Categorys { get; set; }
    }
}
