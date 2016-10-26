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
using FilmEditor.ViewModels;
using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Abstractions;
using FilmEditor.Core.Model;

namespace FilmEditor.Views.ListViews
{
    /// <summary>
    /// Interaction logic for PersonListView.xaml
    /// </summary>
    public partial class PersonListView : Window
    {
        private readonly MainWindow _mainView;

        public PersonListView(MainWindow view)
        {
            InitializeComponent();
            _mainView = view;
            Model = view.PersonModel;
            DataContext = Model;
            Owner = view;
        }


        public PersonListViewModel Model
        {
            get { return (PersonListViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(PersonListViewModel), typeof(PersonListView), new PropertyMetadata(null));



        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Find(object sender, RoutedEventArgs e)
        {
            Model.Find();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Model.Edit();
            Refresh();
        }

        private void Refresh()
        {

            this.Show();
        }

        private void PlayedIn(object sender, RoutedEventArgs e)
        {
            Model.ShowContributions(Role.Actor);
        }

        private void Directed(object sender, RoutedEventArgs e)
        {
            Model.ShowContributions(Role.Director);
        }

        private void Composed(object sender, RoutedEventArgs e)
        {
            Model.ShowContributions(Role.Composer);
        }

        private void New(object sender, RoutedEventArgs e)
        {
            Model.New();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Model.Save();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Model.Delete();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            Model.Update();
        }


        private void personListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.CurrentPerson = e.AddedItems[0] as Person;
        }

        private void SaveAll(object sender, RoutedEventArgs e)
        {
            Model.SaveAll();
        }
    }
}
