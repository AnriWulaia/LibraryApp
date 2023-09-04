using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.models
{
    public class Users
    {
        [BindProperty]
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression("^[a-zA-Z\\s]*$", ErrorMessage = "Please enter text only.")]
        [StringLength(25, ErrorMessage = "Text must be at most 25 characters long.")]
       
        public string Name { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Number is required.")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{3}$", ErrorMessage = "Please enter a valid number in the format 555-555-555")]
        public string Number { get; set; } = "";

        [BindProperty]
        public List<string>? Borrowed { get; set; }
    }
}
