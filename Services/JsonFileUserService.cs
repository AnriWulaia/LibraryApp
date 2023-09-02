using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using Library.models;
using Newtonsoft.Json;

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
            List<Users> users = JsonConvert.DeserializeObject<List<Users>>(json);
            return users;
        }
    }


}
