using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ImageGallery.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.ToTable("Galleries");
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Title).IsRequired().HasMaxLength(100);
                entity.Property(d => d.Description).IsRequired().HasMaxLength(300);
            }
            );
            modelBuilder.Entity<GalleryImage>(entity =>
            {
                entity.ToTable("Images");
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Title).IsRequired().HasMaxLength(100);
                entity.Property(d => d.GalleryId).IsRequired();
                entity.Property(d => d.Photo).IsRequired();
                entity.HasOne(d => d.Gallery).WithMany(d => d.GalleryImages).HasForeignKey(d => d.GalleryId);
            }
         );
        }
    }
}