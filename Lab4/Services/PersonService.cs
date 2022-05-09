using Lab4.Models;
using Lab4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Services
{
    public class PersonService
    {
        private static FileRepository Repository = new FileRepository();

        public List<Person> GetAllPersons()
        {
            var res = new List<Person>();
            foreach (var user in Repository.GetAll())
            {
                
                res.Add(new Person(user.Guid.ToString(), user.FirstName, user.LastName, user.Email, user.Age, user.SunSign, user.ChineseSign));
            }
            return res;
        }
    }
}
