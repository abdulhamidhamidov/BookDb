using System.Net;
using Domain.Dtos.PublisherDtos;
using Domain.Entities;
using Infrastructure.Datas;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PublisherService(DataContext dataContext) : IPublisherService
{
     public async Task<Response<string>> CtearePublisher(CreatePublisherDto request)
    {
        Publisher book = new Publisher();
        book.Name = request.Name;
        book.Address = request.Address;
        book.Website = request.Website;
        book.EstablishedYear = request.EstablishedYear;
        book.ContactEmail = request.ContactEmail;
        await dataContext.Publishers.AddAsync(book);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        return new Response<string>("Created");
    }

    public async Task<Response<List<GetPublisherDto>>> GetPublishers()
    {
        var res = await dataContext.Publishers.ToListAsync();
        var books = res.Select(x=>new GetPublisherDto()
        {
            Name = x.Name,
            Address = x.Address,
            Website = x.Website,
            EstablishedYear = x.EstablishedYear,
            ContactEmail = x.ContactEmail, 
        }).ToList();
        if (books.Count == null)
            return new Response<List<GetPublisherDto>>(HttpStatusCode.NotFound,"Not Found");
        return new Response<List<GetPublisherDto>>(books);
    }

    public async Task<Response<GetPublisherDto>> GetPublisherById(int id)
    {
        var res = await dataContext.Publishers.FirstOrDefaultAsync(x => x.Id == id);
        GetPublisherDto getPublisherDto = new GetPublisherDto();
        getPublisherDto.Name = res.Name;
        getPublisherDto.Address = res.Address;
        getPublisherDto.Website = res.Website;
        getPublisherDto.EstablishedYear = res.EstablishedYear;
        getPublisherDto.ContactEmail = res.ContactEmail;
        if(getPublisherDto==null)
            return new Response<GetPublisherDto>(HttpStatusCode.NotFound,"Not Found");
        return new Response<GetPublisherDto>(getPublisherDto);
        
    }

    public async Task<Response<string>> UpdatePublisher(UpdatePublisherDto request)
    {
        var res = await dataContext.Publishers.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (res == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        res.Name = request.Name;
        res.Address = request.Address;
        res.Website = request.Website;
        res.EstablishedYear = request.EstablishedYear;
        res.ContactEmail = request.ContactEmail;
        var res2 = await dataContext.SaveChangesAsync();
        if (res2 == 0) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        return new Response<string>("Updated");
    }

    public async Task<Response<string>> DeletePublisher(int id)
    {
        var book = await dataContext.Publishers.FirstOrDefaultAsync(x => x.Id == id);
        if (book == null) return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        dataContext.Publishers.Remove(book);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        else return new Response<string>("Deleted");
    }
}