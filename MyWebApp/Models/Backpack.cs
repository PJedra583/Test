using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models;

[PrimaryKey(nameof(CharacterId), nameof(ItemId))]
public class Backpack
{
    
    public int CharacterId { get; set; }
    
    [ForeignKey("CharacterId")]
    public Character Character { get; set; }
    public int ItemId { get; set; }
    [ForeignKey("ItemId")]
    public Item Item { get; set; }
    [Required]
    public int Amount { get; set; }

}