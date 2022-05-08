using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    internal class DBPerson
    {
        public DBPerson(string firstName, string lastName,
            string email, DateTime birthDate,
            bool isAdult, string sunSign, string chineseSign)
        {
            Guid = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate.ToString();
            Status = isAdult ? "adult" : "child";
            SunSign = sunSign;
            ChineseSign = chineseSign;
        }

        public Guid Guid { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string BirthDate { get; }
        public string Email { get; }
        public string Status { get; }
        public string SunSign { get; }
        public string ChineseSign { get; }

    }
}
