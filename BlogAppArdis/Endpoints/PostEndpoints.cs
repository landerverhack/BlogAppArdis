using BlogAppArdis.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlogAppArdis.Endpoints;

/// <summary>
/// A post as returned from the API, without EF Core navigation properties.
/// </summary>
public record PostDto(int Id, string Title, string Content, DateTime CreatedDate, DateTime? UpdatedDate);

public static class PostEndpoints
{
  /// <summary>
  /// Maps API endpoints for retrieving blog posts.
  /// </summary>
  public static void MapPostEndpoints(this WebApplication app)
  {
    app.MapGet("/api/blogs/{blogId:int}/posts", async (int blogId, BlogDbContext db) =>
    {
      var blogExists = await db.Blogs.AnyAsync(b => b.Id == blogId);
      if (!blogExists)
      {
        return Results.NotFound();
      }

      var posts = await db.Posts
              .Where(p => p.BlogId == blogId)
              .OrderByDescending(p => p.CreatedDate)
              .Select(p => new PostDto(p.Id, p.Title, p.Content, p.CreatedDate, p.UpdatedDate))
              .ToListAsync();

      return Results.Ok(posts);
    })
    .WithName("GetPostsForBlog")
    .WithTags("Posts");
    
  }
}
