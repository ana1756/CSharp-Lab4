using Lab4.Exceptions;
using Lab4.Models;
using Lab4.Navigation;
using Lab4.Services;
using Lab4.Utils;
using Lab4.Views;
using System;
using System.Windows;

namespace Lab4.ViewModels
{
    public class AddPersonViewModel : INavigatable<MainNavigationTypes>
    {
        private Person _person;
        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _backCommand;
        private Action _gotoInfoPerson;

        public AddPersonViewModel(Action goToTable)
        {
            _gotoInfoPerson = goToTable;
        }

        #region Properties
        public string Name
        {
            get; set;
        }
        public string Surname
        {
            get; set;
        }
        public string Email
        {
            get; set;
        }
        public DateTime BirthDate
        {
            get; set;
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

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                _proceedCommand = new RelayCommand<object>(_ => Proceed(), CanExecute);
                return _proceedCommand;
            }
        }

        public RelayCommand<object> BackCommand
        {
            get
            {
                _backCommand = new RelayCommand<object>(_ => Back());
                return _backCommand;
            }
        }

        private bool CanExecuteBack()
        {
            return true;
        }



        #endregion


        public MainNavigationTypes ViewType()
        {
            return MainNavigationTypes.AddPerson;
        }

        // initializes person and starts a new window
        private void Proceed()
        {
            try
            {
                _person = new Person(Name, Surname, Email, BirthDate);    
            }
            catch (InvalidEmailException e)
            {
                MessageBox.Show("Error occured: " + e.Message);
                return;
            }
            catch (BirthDateInFutureException e)
            {
                MessageBox.Show("Error occured: " + e.Message);
                return;
            }
            catch (BirthDateInPastException e)
            {
                MessageBox.Show("Error occured: " + e.Message);
                return;
            }

            var authService = new AuthentificationService();
            if (authService.RegisterUser(_person).Result)
            {
                MessageBox.Show("Authentification Succeeded!");
            }
           // _gotoInfoPerson.Invoke();

            ShowInfoView sw = new ShowInfoView(this);
           // Thread.Sleep(2000);
            sw.Show();
            if (IsBirthday)
            {
                MessageBox.Show("Happy Birthday!", "Message");
            }
        }

        private bool CanExecute(object obj)
        {
            return !String.IsNullOrWhiteSpace(Name)
               && !String.IsNullOrWhiteSpace(Surname)
               && !String.IsNullOrWhiteSpace(Email)
               && !(BirthDate.Equals(DateTime.MinValue));
        }

        // goes back to the table
        private void Back()
        {
            _gotoInfoPerson.Invoke();
        }

    }
}
