using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Publisher
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Required,EmailAddress]
    public string ContactEmail { get; set; }
    public DateTime EstablishedYear { get; set; }
    [Required]
    public string Website { get; set; }

    public List<Book> Books { get; set; }
}