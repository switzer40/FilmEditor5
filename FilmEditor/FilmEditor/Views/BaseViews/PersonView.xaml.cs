using FilmEditor.Core.Model;
using FilmEditor.ViewModels;
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
using System.Windows.Shapes;

namespace FilmEditor.Views.BaseViews
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : Window
    {
        public PersonView(PersonListViewModel model)
        {
            InitializeComponent();
            Model = model;
            Person = Model.CurrentPerson;
            DataContext = Person;
            firstNameTextBox.Focus();
        }
        public bool Accept { get; set; }



        public PersonListViewModel Model
        {
            get { return (PersonListViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(PersonListViewModel), typeof(PersonView), new PropertyMetadata(null));



        public Person Person
        {
            get { return (Person)GetValue(PersonProperty); }
            set { SetValue(PersonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Person.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PersonProperty =
            DependencyProperty.Register("Person", typeof(Person), typeof(PersonView), new PropertyMetadata(null));

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DoAccept(object sender, RoutedEventArgs e)
        {
            Accept = true;
            Close();
        }

        private void DoReject(object sender, RoutedEventArgs e)
        {
            Accept = false;
            Close();
        }
    }
}
