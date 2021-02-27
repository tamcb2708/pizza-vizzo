namespace webMVC1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Registers
    {
        public long ID { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string PassWord { get; set; }

        public string ConfirmPassWord { get; set; }

        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
