namespace webMVC1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Quantity { get; set; }

        [StringLength(250)]
        public string DesCription { get; set; }

        public DateTime? CreateDate { get; set; }

        [Column(TypeName = "text")]
        public string Detail { get; set; }

        [StringLength(250)]
        public string Images { get; set; }
    }
}
