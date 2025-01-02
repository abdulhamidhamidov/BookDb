using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Book
{
    public int Id { get; set; }
    [Required,MaxLength(250)]
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    [Required,MaxLength(250)]
    public string Genre { get; set; }
    [Required]
    public int Pages { get; set; }
    [Required]
    public string Language { get; set; }
    [Required,ForeignKey("Author")]
    public int AuthorId { get; set; }
    [Required,ForeignKey("Publisher")]
    public int PublisherId { get; set; }
}