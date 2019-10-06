namespace Training.Dal
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Training.DomainModel;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class TrainingModel : /*DbContext*/ IdentityDbContext /*Microsoft.AspNet.Identity.EntityFramework nuget pcg kell hozzá*/
    {
        public TrainingModel()
            : base("name=TraingingModelConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4)
                .HasColumnType("money"); // ide kerülnek át azok amik db specifikusak

            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .HasColumnType("ntext");

            modelBuilder.Entity<Category>()
                .Property(e => e.Picture)
                .HasColumnType("image");
        }
    }
}
