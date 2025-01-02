using Domain.Dtos.AuthorDtos;
using Domain.Dtos.PublisherDtos;
using Domain.Entities;

namespace Domain.Dtos;

public class GetBookDto
{
    public string Title { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Genre { get; set; }
    public int Pages { get; set; }
    public string Language { get; set; }
    public int AuthorId { get; set; }
    public int PublisherId { get; set; }
}