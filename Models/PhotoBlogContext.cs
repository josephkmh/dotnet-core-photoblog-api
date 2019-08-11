using Microsoft.EntityFrameworkCore;

namespace PhotoBlogApi.Models
{
    public class PhotoBlogApiContext : DbContext
    {
        public PhotoBlogApiContext(DbContextOptions<PhotoBlogApiContext> options)
            : base(options)
        {

        }

        public DbSet<Photo> Photos { get; set; }

    }
}