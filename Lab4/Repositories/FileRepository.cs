using Lab4.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab4.Repositories
{
    class FileRepository
    {
        private static readonly string BaseFolder = 
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LAB4-PersonData");

        public FileRepository()
        {
            if (!Directory.Exists(BaseFolder))
                Directory.CreateDirectory(BaseFolder);
        }

        public async Task AddOrUpdateAsync(DBPerson obj)
        {
            var stringObj = JsonSerializer.Serialize(obj);

            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, obj.LastName + "-" + obj.FirstName), false))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public async Task<DBPerson> GetAsync(string firstName, string lastName)
        {
            string stringObj = null;
            string filePath = Path.Combine(BaseFolder, firstName + "-" + lastName);

            if (!File.Exists(filePath))
                return null;

            using (StreamReader sw = new StreamReader(filePath))
            {
                stringObj = await sw.ReadToEndAsync();
            }

            return JsonSerializer.Deserialize<DBPerson>(stringObj);
        }

        public async Task<List<DBPerson>> GetAllAsync()
        {
            var res = new List<DBPerson>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = await sw.ReadToEndAsync();
                }

                res.Add(JsonSerializer.Deserialize<DBPerson>(stringObj));
            }

            return res;
        }

        public List<DBPerson> GetAll()
        {
            var res = new List<DBPerson>();
            foreach (var file in Directory.EnumerateFiles(BaseFolder))
            {
                string stringObj = null;

                using (StreamReader sw = new StreamReader(file))
                {
                    stringObj = sw.ReadToEnd();
                }

                res.Add(JsonSerializer.Deserialize<DBPerson>(stringObj));
            }

            return res;
        }
    }
}
