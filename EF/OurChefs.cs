namespace webMVC1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OurChefs
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string LinkFb { get; set; }

        [StringLength(250)]
        public string LinkInstagam { get; set; }

        [StringLength(250)]
        public string LinkSwithter { get; set; }

        [StringLength(50)]
        public string office { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? Phone { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(250)]
        public string Descripton { get; set; }
    }
}
