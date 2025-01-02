using Domain.Dtos.PublisherDtos;
using Domain.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IPublisherService
{
    public Task<Response<string>> CtearePublisher(CreatePublisherDto request);
    public Task<Response<List<GetPublisherDto>>> GetPublishers();
    public Task<Response<GetPublisherDto>> GetPublisherById(int id);
    public Task<Response<string>> UpdatePublisher(UpdatePublisherDto request);
    public Task<Response<string>> DeletePublisher(int id);

}