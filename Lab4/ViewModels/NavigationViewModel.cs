using Lab4.Navigation;
using System;
using Lab4.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Lab4.ViewModels
{
     class NavigationViewModel :  BaseNavigatableViewModel<MainNavigationTypes>, INotifyPropertyChanged
    {

        public NavigationViewModel()
        {
            Navigate(MainNavigationTypes.Table);
        }


        // navigates to a viewmodel depending on what is shown currently
        protected override INavigatable<MainNavigationTypes> CreateViewModel(MainNavigationTypes type)
        {
            switch(type)
            {
                case MainNavigationTypes.Table:
                    return new TableViewModel(()=> Navigate(MainNavigationTypes.AddPerson));
                case MainNavigationTypes.AddPerson:
                        return new AddPersonViewModel(() => Navigate(MainNavigationTypes.Table));
                default: return null;
            }
        }
    }


}
