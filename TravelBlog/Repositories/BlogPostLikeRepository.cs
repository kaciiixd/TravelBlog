using Microsoft.EntityFrameworkCore;
using TravelBlog.Data;
using TravelBlog.Models.Domain;

namespace TravelBlog.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly TravelBlogDbContext travelBlogDbContext;

        public BlogPostLikeRepository(TravelBlogDbContext travelBlogDbContext)
        {
            this.travelBlogDbContext = travelBlogDbContext;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await travelBlogDbContext.BlogPostLike.AddAsync(blogPostLike);
            await travelBlogDbContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await travelBlogDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await travelBlogDbContext.BlogPostLike
                .CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
