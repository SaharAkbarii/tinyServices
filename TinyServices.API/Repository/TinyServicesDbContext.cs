using Microsoft.EntityFrameworkCore;
using TinyServices.API.Divar.Model;
using TinyServices.API.Linkedin.Model;
using TinyServices.API.LinkService.Model;
using TinyServices.API.NewsMagazine.Model;


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
    modelBuilder.Entity<Connection>().HasOne(o => o.User).WithMany(o=> o.Conections);
    modelBuilder.Entity<ConnectionRequest>().HasOne(o=> o.Receiver).WithMany(o=> o.ConnectionRequests);
    modelBuilder.Entity<NewsUser>().OwnsOne(o=> o.Email).HasIndex(x=> x.Value).IsUnique();
    modelBuilder.Entity<News>().HasMany(o=> o.Likes).WithOne(x=> x.LikedEntity);
    modelBuilder.Entity<NewsLike<News>>().HasOne(o=> o.NewsUser);
    modelBuilder.Entity<NewsLike<NewsComment>>().HasOne(o=> o.NewsUser);
    modelBuilder.Entity<NewsComment>().HasMany(o=> o.Likes).WithOne(x=> x.LikedEntity);
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
  public DbSet<ConnectionRequest> ConnectionRequests {get; set;}
  public DbSet<Connection> Connections {get; set;}
  public DbSet<News> News {get; set;}
  public DbSet<NewsUser> NewsUsers {get; set;}
  public DbSet<NewsLike<News>> NewsLikes {get; set;}
  public DbSet<NewsLike<NewsComment>> NewsCommentLikes {get; set;}
  public DbSet<NewsDisLike<News>> NewsDisLikes { get; set; }
  public DbSet<NewsDisLike<NewsComment>> NewsCommentDisLikes {get; set;}
  public DbSet<NewsComment> NewsComments { get; set; }
  public DbSet<NewsCategory> NewsCategories { get; set; }
  public DbSet<NewsViewInfo> NewsViewInfos {get; set;}
}
