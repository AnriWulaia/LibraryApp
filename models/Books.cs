using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library.models
{
    public class Books
    {
        public String? Isbn { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Author is required.")]
        public string Author { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Image URL is required.")]
        public string Image { get; set; } = "";

        [BindProperty]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = "";


        public override string ToString() => JsonSerializer.Serialize<Books>(this);
    }

    
}
