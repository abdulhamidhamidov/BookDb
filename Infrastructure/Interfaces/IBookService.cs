using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IBookService
{
    public Task<Response<string>> CteareBook(CreateBookDto request);
    public Task<Response<List<GetBookDto>>> GetBooks();
    public Task<Response<GetBookDto>> GetBookById(int id);
    public Task<Response<string>> UpdateBook(UpdateBookDto request);
    public Task<Response<string>> DeleteBook(int id);

}