using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;

public class Item
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public String Name { get; set; }
    [Required]
    public int Weight { get; set; }
    public ICollection<Backpack> ItemsBackpacks { get; set; } = new HashSet<Backpack>();
}