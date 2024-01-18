using Microsoft.EntityFrameworkCore;
using TravelBlog.Data;
using TravelBlog.Models.Domain;

namespace TravelBlog.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly TravelBlogDbContext travelBlogDbContext;

        public BlogPostCommentRepository(TravelBlogDbContext travelBlogDbContext)
        {
            this.travelBlogDbContext = travelBlogDbContext;
        }

        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await travelBlogDbContext.BlogPostComment.AddAsync(blogPostComment);
            await travelBlogDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
            return await travelBlogDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }
    }
}
