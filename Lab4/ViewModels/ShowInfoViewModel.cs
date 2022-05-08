using Lab4.Models;
using Lab4.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.ViewModels
{
    public class ShowInfoViewModel : INavigatable<MainNavigationTypes>
    {
        private Person _person;

        public ShowInfoViewModel(Person person)
        {
            _person = person;
        }

        #region Properties
        public string Name
        {
            get 
            {
                if (_person == null) return "";
                return _person.Name; 
            }
        }
        public string Surname
        {
            get 
            {
                if (_person == null) return "";
                return _person.Surname; 
            }
        }
        public string Email
        {
            get 
            {
                if (_person == null) return "";
                return _person.Email; 
            }
        }
        public string BirthDate
        {
            get 
            {
                if (_person == null) return "";
                    return _person.BirthDate.ToString(); 
            }
        }

        public string Age
        {
            get
            {
                if (_person == null) return "";
                return _person.Age + " y.o.";
            }
        }

        public string SunSign
        {
            get
            {
                if (_person == null) return "";
                return _person.SunSign;
            }
        }

        public string ChineseSign
        {
            get
            {
                if (_person == null) return "";
                return _person.ChineseSign;
            }
        }

        public string IsAdult
        {
            get
            {
                if (_person == null) return "";
                else if (_person.Age >= 18) return "adult";
                else return "child";
            }
        }

        public bool IsBirthday
        {
            get
            {
                if (_person == null) return false;
                else if (_person.BirthDate.Day.Equals(DateTime.Now.Day)
                    && _person.BirthDate.Month.Equals(DateTime.Now.Month)) return true;
                else return false;
            }
        }

        public string Date
        {
            get
            {
                if (_person == null) return "";
                else return _person.BirthDate.ToShortDateString();
            }
        }

        #endregion



        public MainNavigationTypes ViewType()
        {
            return MainNavigationTypes.ShowInfo;
        }

    }
}
