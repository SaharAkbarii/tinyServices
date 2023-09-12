using Microsoft.EntityFrameworkCore;
using TinyServices.API.Divar.Model;
using TinyServices.API.Linkedin.Model;
using TinyServices.API.LinkService.Model;


namespace TinyServices.API.Repository;
public class TinyServicesDbContext : DbContext
{
  public TinyServicesDbContext(DbContextOptions options)
    : base(options)
  {

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<LinkClickInfo>().HasIndex(x => x.Token).IsUnique(false);
    modelBuilder.Entity<User>().OwnsOne(o => o.Email).HasIndex(x=> x.Value).IsUnique();
    modelBuilder.Entity<User>().OwnsOne(o => o.PhoneNumber).HasIndex(x=> x.Value).IsUnique();
    modelBuilder.Entity<Advertisement>().OwnsOne(o => o.PhoneNumber);
    modelBuilder.Entity<CategoryProperty>().HasIndex("Title", "CategoryId").IsUnique();
    modelBuilder.Entity<LinkedinUser>().OwnsOne(o => o.Email).HasIndex(x=> x.Value).IsUnique();
  }

  public DbSet<ShortLink> ShortLinks { get; set; }
  public DbSet<DeepLink> DeepLinks { get; set; }
  public DbSet<OneTimeLink> oneTimeLinks { get; set; }
  public DbSet<LinkClickInfo> LinkClickInfos { get; set; }
  public DbSet<Company> Companies { get; set; }
  public DbSet<Advertisement> Advertisements { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<CategoryProperty> CategoryProperties { get; set; }
  public DbSet<PropertyValue> PropertyValues { get; set; }
  public DbSet<User> Users { get; set; }
  public DbSet<LinkedinUser> LinkedinUsers {get; set;}
  public DbSet<LinkedinPost> linkedinPosts {get; set;}
  public DbSet<Like> Likes {get; set; }
  public DbSet<Comment> Comments {get; set;}
}
