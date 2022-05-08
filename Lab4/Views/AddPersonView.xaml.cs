using Lab4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab4.Views
{

    public partial class AddPersonView : UserControl
    {

        public AddPersonView()
        {
            InitializeComponent();
            
        }

        private void datePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            
            if (((AddPersonViewModel)DataContext).Date != null)
                if (datePicker!=null && datePicker.SelectedDate != null)
                ((AddPersonViewModel)DataContext).BirthDate = datePicker.SelectedDate.Value;
        }
    }
}
