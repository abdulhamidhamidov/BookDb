using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Author
{
    public int Id { get; set; }
    [Required,MaxLength(250)]
    public string Name { get; set; }
    [Required] 
    public string Biography { get; set; }
    public DateTime DateOfBirth { get; set; }
    [Required] 
    public string Nationality { get; set; }
    public string Awards { get; set; }
    public List<Book> Books { get; set; }

}