using FilmEditor.Core.Abstractions;
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

namespace FilmEditor.Views.ListViews
{
    /// <summary>
    /// Interaction logic for CountryListView.xaml
    /// </summary>
    public partial class CountryListView : Window
    {
        private readonly AbstractCountryRepository _countryRepository;
        private readonly AbstractFilmCountryRepository _filmCountryRepository;
        private readonly AbstractFilmRepository _filmRepository;
        public CountryListView(MainWindow view)
        {
            InitializeComponent();
            Model = view.CountryModel;
            _countryRepository = view.CountryRepository;
            _filmCountryRepository = view.FilmCountryRepository;
            _filmRepository = view.FilmRepository;    
            DataContext = Model;            
        }
        public bool Accept { get; set; }



        public CountryListViewModel Model
        {
            get { return (CountryListViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(CountryListViewModel), typeof(CountryListView), new PropertyMetadata(null));



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

        private void Delete(object sender, RoutedEventArgs e)
        {
            Model.Delete();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            Model.Update();
        }


        private void SaveAll(object sender, RoutedEventArgs e)
        {
            Model.SaveAll();
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
