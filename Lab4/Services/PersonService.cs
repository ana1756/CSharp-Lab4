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

        public List<Person> GetAllPersons()
        {
            var res = new List<Person>();
            foreach (var user in FileRepository.GetAll())
            {
                
                res.Add(new Person(user.ID, user.FirstName, user.LastName, user.Email, user.Age, user.SunSign, user.ChineseSign));
            }
            return res;
        }

    }
}
