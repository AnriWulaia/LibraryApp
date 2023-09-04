using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using Library.models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Services
{
    public class JsonFileUserService
    {

        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "users.json");
        
        public List<Users> GetUsers()
        {
            using StreamReader reader = new(JsonFileName);
            var json = reader.ReadToEnd();
            if (!string.IsNullOrEmpty(json))
            {
                List<Users> users = JsonConvert.DeserializeObject<List<Users>>(json);
                return users;
            }
            return new List<Users>();
        }


        public void AddUser(Users newUser)
        {
            List<Users> users = GetUsers();
            newUser.Name = newUser.Name.Trim();
            newUser.Number = newUser.Number.Trim();


            users.Add(newUser);

            string updatedJsonContent = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true,

            });

            File.WriteAllText(JsonFileName, updatedJsonContent);
        }
    }


}
