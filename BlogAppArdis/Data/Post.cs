namespace BlogAppArdis.Data;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    
    // Foreign key
    public int BlogId { get; set; }
    
    // Navigation property
    public Blog Blog { get; set; } = null!;
}
