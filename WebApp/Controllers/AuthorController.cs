using Domain.Dtos.AuthorDtos;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api[controller]")]
public partial class AuthorController(IAuthorService authorService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CteareAuthor(CreateAuthorDto request)
    {
        return await authorService.CteareAuthor(request);
    }
    [HttpGet]
    public async Task<Response<List<GetAuthorDto>>> GetAuthors()
    {
        return await authorService.GetAuthors();
    }
    [HttpGet("/Author-By-Id")]
    public async Task<Response<GetAuthorDto>> GetAuthorById(int id)
    {
        return await authorService.GetAuthorById(id);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateAuthor(UpdateAuthorDto request)
    {
        return await authorService.UpdateAuthor(request);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteAuthor(int id)
    {
        return await authorService.DeleteAuthor(id);
    }
}