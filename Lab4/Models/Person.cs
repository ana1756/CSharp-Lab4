using Lab4.Exceptions;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class Person
    {
        private static String emailRegex = "^(.+)@(.+)$";
        public event PropertyChangedEventHandler PropertyChanged;

        #region Private Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;

        private string _chineseSign;
        private string _sunSign;
        private int _age;
        #endregion

        #region Properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        #endregion

        #region Read-Only Properties
        public int Age
        {
            get { return _age; }
        }

        public string SunSign
        {
            get { return _sunSign; }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
        }
        #endregion

        #region Constructors
        public Person(string name, string surname, string email, DateTime birthDate)
        {
            if (!Regex.IsMatch(email, emailRegex))
                throw new InvalidEmailException("Invalid email value");
            if (birthDate.CompareTo(DateTime.Now) > 0)
                throw new BirthDateInFutureException("Invalid birth date value");
            if (birthDate.Year < 1887)
                throw new BirthDateInPastException("Invalid birth date value");
            _name = name;
            _surname = surname;
            _email = email;
            _birthDate = birthDate;
            // asynchronous calls 
            CalculateChineseSignAsync();
            CalculateSunSignAsync();
            CalculateAgeAsync();
        }

        public Person(string name, string surname, string email)
            : this(name, surname, email, DateTime.MinValue)
        { }

        public Person(string name, string surname, DateTime birthDate)
            : this(name, surname, "unknown", birthDate)
        { }
        #endregion

        #region Asunchronous Methods
        // asynchronous method for calculation Chinese Sign
        private async void CalculateChineseSignAsync()
        {
            await Task.Run(() => CalculateChineseSign());
        }

        // asynchronous method for calculation Sun Sign
        private async void CalculateSunSignAsync()
        {
            await Task.Run(() => CalculateSunSign());
        }

        // asynchronous method for calculation age
        private async void CalculateAgeAsync()
        {
            await Task.Run(() => CalculateAge());
        }
        #endregion


        // calculates Chinese Sign of a person
        private void CalculateChineseSign()
        {
            string[] cZodiac = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon",
            "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
            int y = BirthDate.Year;
            _chineseSign = cZodiac[(y - 4) % 12];
        }


        // calculates Sun Sign of a person
        private void CalculateSunSign()
        {
            string[] wZodiac = new string[] { "Aries", "Taurus", "Gemini", "Cancer",
            "Leo", "Virgo", "Libra", "Scorpio",
            "Sagittarius", "Capricorn", "Aquarius", "Pisces" };
            int m = BirthDate.Month;
            int d = BirthDate.Day;
            switch (m)
            {
                case 1:
                    _sunSign = (d <= 19) ? wZodiac[9] : wZodiac[10];
                    break;
                case 2:
                    _sunSign = (d <= 18) ? wZodiac[10] : wZodiac[11];
                    break;
                case 3:
                    _sunSign = (d <= 20) ? wZodiac[11] : wZodiac[0];
                    break;
                case 4:
                    _sunSign = (d <= 19) ? wZodiac[0] : wZodiac[1];
                    break;
                case 5:
                    _sunSign = (d <= 20) ? wZodiac[1] : wZodiac[2];
                    break;
                case 6:
                    _sunSign = (d <= 20) ? wZodiac[2] : wZodiac[3];
                    break;
                case 7:
                    _sunSign = (d <= 22) ? wZodiac[3] : wZodiac[4];
                    break;
                case 8:
                    _sunSign = (d <= 22) ? wZodiac[4] : wZodiac[5];
                    break;
                case 9:
                    _sunSign = (d <= 22) ? wZodiac[5] : wZodiac[6];
                    break;
                case 10:
                    _sunSign = (d <= 22) ? wZodiac[6] : wZodiac[7];
                    break;
                case 11:
                    _sunSign = (d <= 21) ? wZodiac[7] : wZodiac[8];
                    break;
                case 12:
                    _sunSign = (d <= 21) ? wZodiac[8] : wZodiac[9];
                    break;
                default:
                    throw new Exception();
            }
        }


        // calculates the age of a person
        private void CalculateAge()
        {
            int years = DateTime.UtcNow.Year - BirthDate.Year;
            int months = DateTime.UtcNow.Month - BirthDate.Month;
            int days = DateTime.UtcNow.Day - BirthDate.Day;
            if (months >= 0)
            {
                if (days >= 0)
                    _age = years;
                else
                    _age = years - 1;
            }
            else _age = years - 1;

        }


        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
