using Lab4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class DBPerson
    {

        #region private fields
        private string _id;
        private string _firstName;
        private string _lastNname;
        private string _email;
        private string _age;
        private string _chineseSign;
        private string _sunSign;
        #endregion

        public DBPerson(string id, string firstName, string lastName, string age,
            string email, string sunSign, string chineseSign)
        {
            _id = id;
            _firstName = firstName;
            _lastNname = lastName;
            _email = email;
            _age = age;
            _sunSign = sunSign;
            _chineseSign = chineseSign;
        }

        #region Properties
        public string ID 
        {
            get { return _id; }
        }

        public string FirstName 
        {
            get { return _firstName; }
            set
            {
                Update(value, FirstName);
                _firstName = value;
            }
        }

        public string LastName 
        {
            get { return _lastNname; }
            set
            {
                Update(value, LastName);
                _lastNname = value;
            }
        }

        public string Age 
        {
            get { return _age; }
            set { _age = value; }
        }

        public int AgeInt
        {
            get 
            { 
               return Int32.Parse(_age); 
            }
        }

        public string IsAdult
        {
            get
            {
                if (AgeInt >= 18)
                    return "adult";
                return "child";
            }
        }

        public string Email 
        {
            get { return _email; }
            set
            {
                Update(value, Email);
                _email = value;
            }
        }
       
        public string SunSign 
        {
            get { return _sunSign; }
            set { _sunSign = value; }
        }

        public string ChineseSign 
        {
            get { return _chineseSign; }
            set { _chineseSign = value; }
        }

        private async void Update(string oldName, string newName)
        {
            await FileRepository.Update(ID, oldName, newName);
        }
        #endregion






    }
}
