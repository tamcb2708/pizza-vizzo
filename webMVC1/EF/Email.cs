namespace webMVC1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Email")]
    public partial class Email
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Email1 { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
