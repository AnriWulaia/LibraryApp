using Library.models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public JsonFileBookService BooksService;
        public IEnumerable<Books>? Books { get; private set; }


        public IndexModel(ILogger<IndexModel> logger,
            JsonFileBookService bookService)
        {
            _logger = logger;
            BooksService = bookService;

        }

        public void OnGet()
        {
            Books = BooksService.GetBooks();
        }

        public void OnPost()
        {

        }
    }
}