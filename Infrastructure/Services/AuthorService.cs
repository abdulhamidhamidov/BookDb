using System.Net;
using Domain.Dtos.AuthorDtos;
using Domain.Entities;
using Infrastructure.Datas;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AuthorService(DataContext dataContext): IAuthorService
{
     public async Task<Response<string>> CteareAuthor(CreateAuthorDto request)
    {
        Author author = new Author();
        author.Name = request.Name;
        author.Awards = request.Awards;
        author.Biography = request.Biography;
        author.Nationality = request.Nationality;
        author.DateOfBirth = request.DateOfBirth;
        await dataContext.Authors.AddAsync(author);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        return new Response<string>("Created");
    }

    public async Task<Response<List<GetAuthorDto>>> GetAuthors()
    {
        var res = await dataContext.Authors.ToListAsync();
        var authors = res.Select(x=>new GetAuthorDto()
        {
            Name = x.Name,
            Awards = x.Awards,
            Biography = x.Biography,
            Nationality = x.Nationality,
            DateOfBirth = x.DateOfBirth
        }).ToList();
        if (authors.Count == null)
            return new Response<List<GetAuthorDto>>(HttpStatusCode.NotFound,"Not Found");
        return new Response<List<GetAuthorDto>>(authors);
    }

    public async Task<Response<GetAuthorDto>> GetAuthorById(int id)
    {
        var res = await dataContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        GetAuthorDto getAuthorDto = new GetAuthorDto();
        getAuthorDto.Name = res.Name;
        getAuthorDto.Awards = res.Awards;
        getAuthorDto.Biography = res.Biography;
        getAuthorDto.Nationality = res.Nationality;
        getAuthorDto.DateOfBirth = res.DateOfBirth;
        if(getAuthorDto==null)
            return new Response<GetAuthorDto>(HttpStatusCode.NotFound,"Not Found");
        return new Response<GetAuthorDto>(getAuthorDto);
        
    }

    public async Task<Response<string>> UpdateAuthor(UpdateAuthorDto request)
    {
        var res = await dataContext.Authors.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (res == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        res.Name = request.Name;
        res.Awards = request.Awards;
        res.Biography = request.Biography;
        res.Nationality = request.Nationality;
        res.DateOfBirth = request.DateOfBirth;
        var res2 = await dataContext.SaveChangesAsync();
        if (res2 == 0) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        return new Response<string>("Updated");
    }

    public async Task<Response<string>> DeleteAuthor(int id)
    {
        var author = await dataContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
        if (author == null) return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        dataContext.Authors.Remove(author);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        else return new Response<string>("Deleted");
    }
}