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
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (IsImageUrlValid(Book.Image))
                {
                    _bookService.AddBook(Book);

                    return RedirectToPage("Index");
                }
                else
                {
                    
                    ModelState.AddModelError("Book.Image", "Invalid image URL.");
                }
            }

            return Page();
        }

        private bool IsImageUrlValid(string imageUrl)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(imageUrl).Result;
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
