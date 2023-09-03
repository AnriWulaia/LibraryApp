using Library.models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("/book")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly JsonFileBookService _bookService;

        public BooksController(JsonFileBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<Books> Get()
        {
            return _bookService.GetBooks();
        }
    }
}
