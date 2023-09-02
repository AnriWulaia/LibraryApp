using Library.models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Pages
{
    public class UserModel : PageModel
    {
        private readonly ILogger<UserModel> _logger;
        public JsonFileUserService UserService;
        public IEnumerable<Users>? Users { get; private set; }

        public UserModel(ILogger<UserModel> logger,
            JsonFileUserService userservice)
        {
            _logger = logger;
            UserService = userservice;
        }

        public void OnGet()
        {
            Users = UserService.GetUsers();
        }

    }
}