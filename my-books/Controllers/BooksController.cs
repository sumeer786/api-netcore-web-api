using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allbooks = _bookService.GetAllBooks();
            return Ok(allbooks) ;
        }

        [HttpGet("get-all-book-by-id/{id}")]
        public IActionResult GetBooksById(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookService.AddBookWithAuthors(book);
            return Ok(book);
        }
        
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updateBook = _bookService.UpdateBookById(id, book);
            return Ok(updateBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _bookService.DeleteBookById(id);
            return Ok();

        }
    }
}
