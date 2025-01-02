
using Domain.Dtos.PublisherDtos;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api[controller]")]
public partial class PublisherController(IPublisherService authorService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CtearePublisher(CreatePublisherDto request)
    {
        return await authorService.CtearePublisher(request);
    }
    [HttpGet]
    public async Task<Response<List<GetPublisherDto>>> GetPublishers()
    {
        return await authorService.GetPublishers();
    }
    [HttpGet("/Publisher-By-Id")]
    public async Task<Response<GetPublisherDto>> GetPublisherById(int id)
    {
        return await authorService.GetPublisherById(id);
    }
    [HttpPut]
    public async Task<Response<string>> UpdatePublisher(UpdatePublisherDto request)
    {
        return await authorService.UpdatePublisher(request);
    }
    [HttpDelete]
    public async Task<Response<string>> DeletePublisher(int id)
    {
        return await authorService.DeletePublisher(id);
    }
}