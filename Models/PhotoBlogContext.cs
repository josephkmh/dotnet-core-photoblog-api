using Microsoft.EntityFrameworkCore;

namespace PhotoBlogApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Photo> Photos { get; set; }

    }
}