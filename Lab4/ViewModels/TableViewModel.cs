using JetBrains.Annotations;
using Lab4.Models;
using Lab4.Navigation;
using Lab4.Repositories;
using Lab4.Services;
using Lab4.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.ViewModels
{
    internal class TableViewModel :  INavigatable<MainNavigationTypes>, INotifyPropertyChanged
    {
        private Action _gotoAddPerson;
        private RelayCommand<object> _addPersonCommand;

        public ObservableCollection<Person> _users;
        private PersonService _personService;

        public event PropertyChangedEventHandler PropertyChanged;
        FileRepository fileRepository;

        public List<DBPerson> Users
        {
            get => FileRepository.GetAll();
           
        }


        public MainNavigationTypes ViewType()
        { return MainNavigationTypes.Table; }

        public TableViewModel(Action gotoAddPerson)
        {
            _gotoAddPerson = gotoAddPerson;
            _personService = new PersonService();
            _users = new ObservableCollection<Person>(_personService.GetAllPersons());
            fileRepository = new FileRepository();
        }

        public RelayCommand<object> AddPersonCommand
        {
            get
            {
                if (_addPersonCommand == null)
                    return _addPersonCommand = new RelayCommand<object>(_ => AddPerson(), CanExecute);
                return _addPersonCommand;
            }
        }

        private void AddPerson()
        {
            _gotoAddPerson.Invoke();
            
        }

        private bool CanExecute(object obj)
        {
            return true;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
 

}

