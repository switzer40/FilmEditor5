using FilmEditor.Core.Abstractions;
using FilmEditor.Core.Model;
using FilmEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FilmEditor.Views.ListViews
{
    /// <summary>
    /// Interaction logic for LocationListView.xaml
    /// </summary>
    public partial class LocationListView : Window
    {
        private readonly AbstractLocationRepository _locationRepository
            ;
        public LocationListView(MainWindow view)
        {
            InitializeComponent();
            _locationRepository = view.LocationRepository;
            Model = view.LocationModel;
            DataContext = Model;
        }



        public LocationListViewModel Model
        {
            get { return (LocationListViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(LocationListViewModel), typeof(LocationListView), new PropertyMetadata(null));







        
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
        }

        private void New(object sender, RoutedEventArgs e)
        {
            Model.New();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Model.Save();
        }

        private void SaveAll(object sender, RoutedEventArgs e)
        {
            Model.SaveAll();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Model.Delete();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            Model.Update();
        }

        private void StoredFilms(object sender, RoutedEventArgs e)
        {
            Model.StoredFilms();
        }

        private void locationListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void locationListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
    