namespace webMVC1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slidebar")]
    public partial class Slidebar
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string image { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        public bool? stastus { get; set; }
    }
}
