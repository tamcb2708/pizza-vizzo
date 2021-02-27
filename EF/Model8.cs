namespace webMVC1.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model8 : DbContext
    {
        public Model8()
            : base("name=Model8")
        {
        }
        public virtual DbSet<Email> Email { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<webMVC1.EF.questionandanswer> questionandanswers { get; set; }
    }
}
