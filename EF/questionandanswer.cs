namespace webMVC1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("questionandanswer")]
    public partial class questionandanswer
    {
        public long ID { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? Phone { get; set; }

        [StringLength(10)]
        public string Subject { get; set; }
        public bool status { get; set; }
    }
}
