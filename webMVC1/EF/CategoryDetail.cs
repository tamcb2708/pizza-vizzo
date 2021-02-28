namespace webMVC1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryDetail")]
    public partial class CategoryDetail
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string MetaTitle { get; set; }

        public int? DetailID { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }

        public string DesCription { get; set; }

        [StringLength(50)]
        public string Question { get; set; }

        [StringLength(250)]
        public string answer { get; set; }

        [StringLength(250)]
        public string Images { get; set; }
    }
}
