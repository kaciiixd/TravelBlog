using Microsoft.AspNetCore.Identity;

namespace TravelBlog.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
