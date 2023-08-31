using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Library.models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Library.Services
{
    public class JsonFileBookService
    {
        public JsonFileBookService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "books.json");

        public IEnumerable<Books> GetBooks()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Books[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

        }



        //public bool AddBook(string title, string author, string image, string description, out string errorMessage)
        //{
        //    if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) ||
        //        string.IsNullOrWhiteSpace(image) || string.IsNullOrWhiteSpace(description))
        //    {
        //        errorMessage = "All fields are required.";
        //        return false;
        //    }

        //    errorMessage = null;
        //    // Perform further processing here (e.g., adding the book to the database)
        //    return true;
        //}
    }
}
