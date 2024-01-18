using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace TravelBlog.Models.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }


        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
