using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Library.models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

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
                    PropertyNameCaseInsensitive = true,
                });

        }



        public void AddBook(Books newBook)
        {
            string jsonContent = File.ReadAllText(JsonFileName);
            List<Books> books = JsonSerializer.Deserialize<List<Books>>(jsonContent);

            newBook.Title = newBook.Title.Trim();
            newBook.Author = newBook.Author.Trim();
            newBook.Image = newBook.Image.Trim();
            newBook.Description = newBook.Description.Trim();
            

            books.Add(newBook);

            string updatedJsonContent = JsonSerializer.Serialize(books, new JsonSerializerOptions
            {
                WriteIndented = true,
                
            });

            File.WriteAllText(JsonFileName, updatedJsonContent);
        }
    }
}
