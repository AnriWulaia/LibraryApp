using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.models
{
    public class Users
    {
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Number is required.")]
        public string Number { get; set; } = "";

        [BindProperty]
        public List<string>? Borrowed { get; set; }
    }
}
