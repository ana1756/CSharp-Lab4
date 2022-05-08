using Lab4.Navigation;
using Lab4.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.ViewModels
{
    internal class TableViewModel : INavigatable<MainNavigationTypes>
    {
        private Action _gotoAddPerson;
        private RelayCommand<object> _addPersonCommand;
        

        public MainNavigationTypes ViewType()
        { return MainNavigationTypes.Table; }

        public TableViewModel(Action gotoAddPerson)
        {
            _gotoAddPerson = gotoAddPerson;
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
    }
 

}

