namespace Domain.Dtos.PublisherDtos;

public class GetPublisherDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactEmail { get; set; }
    public DateTime EstablishedYear { get; set; }
    public string Website { get; set; }
}