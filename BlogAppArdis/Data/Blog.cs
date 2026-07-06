namespace BlogAppArdis.Data;

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    
    // Navigation property
    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
