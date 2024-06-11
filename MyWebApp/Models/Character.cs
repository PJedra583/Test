using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models;

public class Character
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public String FirstName { get; set; }
    [Required]
    [MaxLength(120)]
    public String LastName { get; set; }
    [Required]
    public int CurrentWeight { get; set; }
    [Required]
    public int MaxWeight { get; set; }
    public ICollection<Backpack> CharacterItems { get; set; } = new HashSet<Backpack>();
    public ICollection<Character_title> CharacterTitles { get; set; } = new HashSet<Character_title>();
    
}