using Microsoft.EntityFrameworkCore;
using TravelBlog.Models.Domain;

namespace TravelBlog.Data
{
    public class TravelBlogDbContext : DbContext
    {
        public TravelBlogDbContext(DbContextOptions<TravelBlogDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostLike> BlogPostLike { get; set; }
        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}
