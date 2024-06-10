using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Models;

public class Models
{
    
}

public class Author
{
    [Key] 
	public int Id { get; set; }
    [Required] 
	public string Name { get; set; }
    public ICollection<Book> Books { get; set; } = new HashSet<Book>();
}

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
    
    public int AuthorId { get; set; }

    [ForeignKey("AuthorId")]
    public Author Author { get; set; }

    public ICollection<BookPublisher> BookPublishers { get; set; } = new HashSet<BookPublisher>();

    public ICollection<Review> Reviews { get; set; } = new HashSet<Review>(); 
}

public class Publisher
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    public ICollection<BookPublisher> BookPublishers { get; set; } = new HashSet<BookPublisher>();
}

[PrimaryKey(nameof(BookId), nameof(PublisherId))]
public class BookPublisher
{
    public int BookId { get; set; }

    [ForeignKey("BookId")]
    public Book Book { get; set; }

    public int PublisherId { get; set; }

    [ForeignKey("PublisherId")]
    public Publisher Publisher { get; set; }
}

public class Review
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Content { get; set; }

    public int BookId { get; set; }

    [ForeignKey("BookId")]
    public Book Book { get; set; }
}