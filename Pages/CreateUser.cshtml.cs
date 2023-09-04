using Library.models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Library.Pages
{
    [BindProperties]
    public class CreateUserModel : PageModel
    {
        public Users User { get; set; }
        public List<string> Borrowed { get; set; }

        public IEnumerable<Books>? Books { get; private set; }

        private readonly JsonFileUserService _userService;
        private readonly JsonFileBookService _bookservice;
        public CreateUserModel(JsonFileUserService userservice, JsonFileBookService bookservice)
        {
            _userService = userservice;
            _bookservice = bookservice;
        }
        public async Task<IActionResult> OnPost()
        {
            List<Users> users = _userService.GetUsers();

            HashSet<string> existingNames = new HashSet<string>(users.Select(user => user.Name.ToLower()));

            if (existingNames.Contains(User.Name.ToLower()))
            {
                TempData["FailedName"] = $"{User.Name} already exists";
                return RedirectToPage("Users");
            }

            User.Borrowed = Borrowed;

            _userService.AddUser(User);
            
            return RedirectToPage("Users");
        }

        

        public void OnGet()
        {
            Books = _bookservice.GetBooks();
        }
    }
}
