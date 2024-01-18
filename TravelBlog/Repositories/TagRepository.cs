using Microsoft.EntityFrameworkCore;
using TravelBlog.Data;
using TravelBlog.Models.Domain;

namespace TravelBlog.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly TravelBlogDbContext travelBlogDbContext;

        public TagRepository(TravelBlogDbContext travelBlogDbContext)
        {
            this.travelBlogDbContext = travelBlogDbContext;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await travelBlogDbContext.Tags.AddAsync(tag);
            await travelBlogDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await travelBlogDbContext.Tags.FindAsync(id);

            if (existingTag != null)
            {
                travelBlogDbContext.Tags.Remove(existingTag);
                await travelBlogDbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await travelBlogDbContext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
            return travelBlogDbContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await travelBlogDbContext.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await travelBlogDbContext.SaveChangesAsync();

                return existingTag;
            }

            return null;
        }
    }
}
