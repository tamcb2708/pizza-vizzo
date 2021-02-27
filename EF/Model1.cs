namespace webMVC1.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {

        }

        public virtual DbSet<Categorys> Categorys { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorys>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Categorys>()
                .Property(e => e.ModifiedDate)
                .IsUnicode(false);

            modelBuilder.Entity<Categorys>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Categorys>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.Categorys)
                .HasForeignKey(e => e.CategoryID);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Detail)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ModifiedDate)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.MetaDescriptions)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ModifiedDate)
                .IsUnicode(false);
        }

        public System.Data.Entity.DbSet<webMVC1.EF.About> Abouts { get; set; }

        public System.Data.Entity.DbSet<webMVC1.EF.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<webMVC1.EF.Content> Contents { get; set; }

        public System.Data.Entity.DbSet<webMVC1.EF.Detail> Details { get; set; }

        public System.Data.Entity.DbSet<webMVC1.EF.Menu> Menus { get; set; }

        public System.Data.Entity.DbSet<webMVC1.EF.MenuType> MenuTypes { get; set; }

        public System.Data.Entity.DbSet<webMVC1.EF.OurChefs> OurChefs { get; set; }

        public System.Data.Entity.DbSet<webMVC1.Models.Register> Registers { get; set; }

        public System.Data.Entity.DbSet<webMVC1.Models.Login> Logins { get; set; }

        public System.Data.Entity.DbSet<webMVC1.Models.ProductView> ProductViews { get; set; }
    }
}
