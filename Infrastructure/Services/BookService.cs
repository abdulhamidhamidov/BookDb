using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Datas;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BookService(DataContext dataContext): IBookService
{
     public async Task<Response<string>> CteareBook(CreateBookDto request)
    {
        Book book = new Book();
        book.Title = request.Title;
        book.PublicationDate = request.PublicationDate;
        book.Genre = request.Genre;
        book.Pages = request.Pages;
        book.Language = request.Language;
        book.AuthorId = request.AuthorId;
        book.PublisherId = request.PublisherId;
        await dataContext.Books.AddAsync(book);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        return new Response<string>("Created");
    }

    public async Task<Response<List<GetBookDto>>> GetBooks()
    {
        var res = await dataContext.Books.ToListAsync();
        var books = res.Select(x=>new GetBookDto()
        {
            Title = x.Title,
            PublicationDate = x.PublicationDate,
            Genre = x.Genre,
            Pages = x.Pages,
            Language = x.Language,
            AuthorId = x.AuthorId,
            PublisherId = x.PublisherId,
        }).ToList();
        if (books.Count == null)
            return new Response<List<GetBookDto>>(HttpStatusCode.NotFound,"Not Found");
        return new Response<List<GetBookDto>>(books);
    }

    public async Task<Response<GetBookDto>> GetBookById(int id)
    {
        var res = await dataContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        GetBookDto getBookDto = new GetBookDto();
        res.Title = getBookDto.Title;
        res.PublicationDate = getBookDto.PublicationDate;
        res.Genre = getBookDto.Genre;
        res.Pages = getBookDto.Pages;
        res.Language = getBookDto.Language;
        res.AuthorId = getBookDto.AuthorId;
        res.PublisherId = getBookDto.PublisherId;
        if(getBookDto==null)
            return new Response<GetBookDto>(HttpStatusCode.NotFound,"Not Found");
        return new Response<GetBookDto>(getBookDto);
        
    }

    public async Task<Response<string>> UpdateBook(UpdateBookDto request)
    {
        var res = await dataContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (res == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        res.Title = request.Title;
        res.PublicationDate = request.PublicationDate;
        res.Genre = request.Genre;
        res.Pages = request.Pages;
        res.Language = request.Language;
        res.AuthorId = request.AuthorId;
        res.PublisherId = request.PublisherId;
        var res2 = await dataContext.SaveChangesAsync();
        if (res2 == 0) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        return new Response<string>("Updated");
    }

    public async Task<Response<string>> DeleteBook(int id)
    {
        var book = await dataContext.Books.FirstOrDefaultAsync(x => x.Id == id);
        if (book == null) return new Response<string>(HttpStatusCode.InternalServerError,"Internal Server Error");
        dataContext.Books.Remove(book);
        var res = await dataContext.SaveChangesAsync();
        if (res == 0) return new Response<string>(HttpStatusCode.NotFound, "Not Found");
        else return new Response<string>("Deleted");
    }
}