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
            foreach (var user in FileRepository.GetAll())
            {
                
                res.Add(new Person(user.ID, user.FirstName, user.LastName, user.Email, user.Age, user.SunSign, user.ChineseSign));
            }
            return res;
        }

        public static Person convert(DBPerson p)
        {
            return new Person(p.ID, p.FirstName, p.LastName, p.Email, p.Age, p.SunSign, p.ChineseSign);
        }
    }
}
