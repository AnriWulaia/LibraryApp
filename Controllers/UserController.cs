using Microsoft.AspNetCore.Mvc;
using Library.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        JsonFileUserService userService;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger,
            JsonFileUserService userservice)
        {
            _logger = logger;
            userService = userservice;
        }


        [HttpPost]
        [Route("Users/DeleteBook")]
        public IActionResult DeleteBook(string userName, string bookToDelete)
        {

            try
            {
                userService.deleteBook(userName, bookToDelete);

                // Return a success response
                return Ok(new { message = "Book deleted successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");

                // Return an error response with the exception message
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost]
        [Route("Users/addBooks")]
        public IActionResult addBooks(string userName, List<string> selectedBooks)
        {

            try
            {
                userService.addBooks(userName, selectedBooks);

                return Ok(new { message = "Book deleted successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");

                // Return an error response with the exception message
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
