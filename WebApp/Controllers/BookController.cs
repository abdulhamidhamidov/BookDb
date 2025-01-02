using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("/api[controller]")]
public class BookController(IBookService bookService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CteareBook(CreateBookDto request)
    {
        return await bookService.CteareBook(request);
    }
    [HttpGet]
    public async Task<Response<List<GetBookDto>>> GetBooks()
    {
        return await bookService.GetBooks();
    }
    [HttpGet("/Book-By-Id")]
    public async Task<Response<GetBookDto>> GetBookById(int id)
    {
        return await bookService.GetBookById(id);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateBook(UpdateBookDto request)
    {
        return await bookService.UpdateBook(request);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteBook(int id)
    {
        return await bookService.DeleteBook(id);
    }
}