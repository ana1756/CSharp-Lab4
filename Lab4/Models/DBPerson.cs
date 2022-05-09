using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    internal class DBPerson
    {


        public DBPerson(string firstName, string lastName, string age,
            string email,  string sunSign, string chineseSign)
        {
            Guid = Guid.NewGuid();// той самий guid
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            
            SunSign = sunSign;
            ChineseSign = chineseSign;
        }

        public Guid Guid { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Age { get; }
        public string Email { get; }
       
        public string SunSign { get; }
        public string ChineseSign { get; }

    }
}
