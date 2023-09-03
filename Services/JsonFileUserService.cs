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
            if (!string.IsNullOrEmpty(json))
            {
                List<Users> users = JsonConvert.DeserializeObject<List<Users>>(json);
                return users;
            }
            return new List<Users>();
        }
        public void AddUser(Users newUser)
        {
            string jsonContent = File.ReadAllText(JsonFileName);
            List<Users> users = JsonConvert.DeserializeObject<List<Users>>(jsonContent);

            newUser.Name = newUser.Name.Trim();
            newUser.Number = newUser.Number.Trim();
            if (newUser.Borrowed != null)
            {
                for (int i = 0; i < newUser.Borrowed.Count; i++)
                {
                    newUser.Borrowed[i] = newUser.Borrowed[i].Trim();
                }
            }


            users.Add(newUser);

            string updatedJsonContent = JsonConvert.SerializeObject(users);

            File.WriteAllText(JsonFileName, updatedJsonContent);
        }
    }


}
