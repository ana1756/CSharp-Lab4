using JetBrains.Annotations;
using Lab4.Models;
using Lab4.Repositories;
using Lab4.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab4.Views
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : System.Windows.Controls.UserControl
    {
        public TableView()
        {
            InitializeComponent();

        }

        public List<DBPerson> Users
        {
            get => FileRepository.GetAll();



        }

        private static readonly string BaseFolder =
           System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LAB4-PersonData");



        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string message = "Do you want to delete this person?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = System.Windows.Forms.MessageBox.Show(message, title, buttons);

            if (result == DialogResult.Yes)
            {
                DBPerson p = (DBPerson) MyData.SelectedItem;
                if (File.Exists(System.IO.Path.Combine(BaseFolder, "person-" + p.ID)))
                {
                    File.Delete(System.IO.Path.Combine(BaseFolder, "person-" + p.ID));
                }
                MyData.ItemsSource = Users;

            }
            else
            {

            }





        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Person p = (Person)MyData.SelectedItem;
            

            if (File.Exists(System.IO.Path.Combine(BaseFolder, "person-" + p.ID)))
            {
                File.Delete(System.IO.Path.Combine(BaseFolder, "person-" + p.ID));
            }
            MyData.ItemsSource = Users; 

        }
    }
}
