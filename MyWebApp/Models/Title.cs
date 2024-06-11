using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;

public class Title
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public String Name { get; set; }
    public ICollection<Character_title> Charactertitles { get; set; } = new HashSet<Character_title>();

}