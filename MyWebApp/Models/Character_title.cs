using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models;

[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class Character_title
{
    public int CharacterId { get; set; }
    [ForeignKey("CharacterId")]
    public Character Character { get; set; }
    public int TitleId { get; set; }
    [ForeignKey("TitleId")]
    public Title Title { get; set; }
    [Required]
    public DateTime AcquiredAt { get; set; }

}