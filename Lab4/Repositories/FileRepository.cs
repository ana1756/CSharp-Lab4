using Lab4.Models;
using Lab4.Services;
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

        public static async Task<int> GetID()
        {
            Random random = new Random();
            return random.Next();
            
        }

        public static async Task AddOrUpdateAsync(DBPerson obj)
        {
            var stringObj = JsonSerializer.Serialize(obj);

            using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, "person-" + obj.ID), false))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public static async Task Update(string id, string name, string oldname)
        {
            if (File.Exists(System.IO.Path.Combine(BaseFolder, "person-" + id)))
            {

                string json = File.ReadAllText(System.IO.Path.Combine(BaseFolder, "person-" + id));
                string a = json.Replace(oldname, name);
                int i = a.Length;
                File.Delete(System.IO.Path.Combine(BaseFolder, "person-" + id));

                using (StreamWriter sw = new StreamWriter(Path.Combine(BaseFolder, "person-" + id), false))
                {
                    await sw.WriteAsync(a);
                }


            }
        }





        public async Task<DBPerson> GetAsync(string id)
        {
            string stringObj = null;
            string filePath = Path.Combine(BaseFolder, "person-" + id);

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

        public static List<DBPerson> GetAll()
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
