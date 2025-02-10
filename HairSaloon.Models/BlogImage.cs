using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HairSaloon.Models;

public class BlogImage
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    public int BlogId { get; set; }
    [ForeignKey("BlogId")]
    public Blog Blog { get; set; }

}
