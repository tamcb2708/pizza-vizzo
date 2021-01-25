namespace webMVC1.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model6 : DbContext
    {
        public Model6()
            : base("name=Model6")
        {
        }

        public virtual DbSet<OderDetail> OderDetail { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipMoblie)
                .IsUnicode(false);
        }
    }
}
