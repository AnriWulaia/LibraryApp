using Library.models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Pages
{
    public class CreateUserModel : PageModel
    {
        public Users User { get; set; }
        public IEnumerable<Books>? Books { get; private set; }

        private readonly JsonFileUserService _userService;
        private readonly JsonFileBookService _bookservice;
        public CreateUserModel(JsonFileUserService userservice, JsonFileBookService bookservice)
        {
            _userService = userservice;
            _bookservice = bookservice;
        }

        public void OnGet()
        {
            Books = _bookservice.GetBooks();
        }
    }
}
