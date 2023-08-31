using Library.models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly JsonFileBookService _bookService;

        public BooksController(JsonFileBookService bookService)
        {
            _bookService = bookService;
        }

        //[HttpPost]
        //public IActionResult AddBook(string title, string author, string image, string description)
        //{
        //    if (_bookService.AddBook(title, author, image, description, out string errorMessage))
        //    {
        //        // Book added successfully
        //        return RedirectToAction(""); // Redirect to appropriate action
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, errorMessage);
        //        // Return the view with validation errors
        //        return View("AddBook"); // Use the appropriate view name
        //    }
        //}
        [HttpGet]
        public IEnumerable<Books> Get()
        {
            return _bookService.GetBooks();
        }
    }
}
