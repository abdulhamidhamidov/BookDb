namespace Domain.Dtos.AuthorDtos;

public class CreateAuthorDto
{
    public string Name { get; set; }
    public string Biography { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Nationality { get; set; }
    public string Awards { get; set; }
}