using Library.models;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net;

namespace Library.Pages
{
    [BindProperties]
    public class CreateBookModel : PageModel
    {
        public Books Book { get; set; }

        private readonly JsonFileBookService _bookService;

        public CreateBookModel(JsonFileBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (IsImageUrl(Book.Image))
                {
                    _bookService.AddBook(Book);
                    TempData["SuccessMessage"] = "Item added successfully";

                    return RedirectToPage("Index");
                }
                else
                {
                    
                    ModelState.AddModelError("Book.Image", "Invalid image URL.");
                }
            }

            return Page();
        }

        private bool IsImageUrl(string url)
        {
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                return IsImageExtension(uri.AbsolutePath);
            }

            return false;
        }

        private bool IsImageExtension(string filePath)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

            string fileExtension = Path.GetExtension(filePath).ToLower();
            return Array.Exists(imageExtensions, ext => ext == fileExtension);
        }
    }
}
