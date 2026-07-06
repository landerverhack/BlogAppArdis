using BlogAppArdis.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BlogAppArdis.Data;

public class BlogDbContext(DbContextOptions<BlogDbContext> options) : DbContext(options)
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BlogConfiguration());
        modelBuilder.ApplyConfiguration(new PostConfiguration());
    }
}
