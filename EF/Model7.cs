namespace webMVC1.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model7 : DbContext
    {
        public Model7()
            : base("name=Model71")
        {
        }

        public virtual DbSet<questionandanswer> questionandanswer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<questionandanswer>()
                .Property(e => e.Subject)
                .IsFixedLength();
        }
    }
}
