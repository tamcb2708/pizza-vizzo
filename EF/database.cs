using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace webMVC1.EF
{
    public partial class database : DbContext
    {
        public database()
            : base("name=database")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<CategoryDetail> CategoryDetail { get; set; }
        public virtual DbSet<Categorys> Categorys { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Content> Content { get; set; }
        public virtual DbSet<ContentTag> ContentTag { get; set; }
        public virtual DbSet<Detail> Detail { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<FeedBack> FeedBack { get; set; }
        public virtual DbSet<Footer> Footer { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuType> MenuType { get; set; }
        public virtual DbSet<OderDetail> OderDetail { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OurChefs> OurChefs { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductViews> ProductViews { get; set; }
        public virtual DbSet<questionandanswer> questionandanswer { get; set; }
        public virtual DbSet<Registers> Registers { get; set; }
        public virtual DbSet<Slidebar> Slidebar { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.Detail)
                .IsUnicode(false);

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

            modelBuilder.Entity<Content>()
                .Property(e => e.Detail)
                .IsUnicode(false);

            modelBuilder.Entity<ContentTag>()
                .Property(e => e.TagID)
                .IsUnicode(false);

            modelBuilder.Entity<Detail>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<Footer>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<OderDetail>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.ShipMoblie)
                .IsUnicode(false);

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

            modelBuilder.Entity<questionandanswer>()
                .Property(e => e.Subject)
                .IsFixedLength();

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
        }
    }
}
