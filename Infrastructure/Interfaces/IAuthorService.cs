using Domain.Dtos;
using Domain.Dtos.AuthorDtos;
using Domain.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IAuthorService
{
    public Task<Response<string>> CteareAuthor(CreateAuthorDto request);
    public Task<Response<List<GetAuthorDto>>> GetAuthors();
    public Task<Response<GetAuthorDto>> GetAuthorById(int id);
    public Task<Response<string>> UpdateAuthor(UpdateAuthorDto request);
    public Task<Response<string>> DeleteAuthor(int id);

}