using FilmEditor.Core.Abstractions;
using FilmEditor.Infrastructure.DAL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using FilmEditor.Infrastructure.ConcreteRepositories;
using FilmEditor.Infrastructure.ConcreteRepositories.EntityFramework;
using FilmEditor.Infrastructure.ConcreteRepositories.InMemory;
using FilmEditor.Core.Model;
using FilmEditor.Views.BaseViews;
using FilmEditor.Views.ListViews;

namespace FilmEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _persist = false;


        public AbstractCountryRepository CountryRepository { get; set; }
        public AbstractFilmCountryRepository FilmCountryRepository { get; set; }
        public AbstractFilmPersonRepository FilmPersonRepository { get; set; }
        public AbstractFilmRepository FilmRepository { get; set; }
        public AbstractLocationRepository LocationRepository { get; set; }
        public AbstractPersonRepository PersonRepository { get; set; }
        public FilmListViewModel FilmModel { get; set; }
        public PersonListViewModel PersonModel { get; set; }
        public CountryListViewModel CountryModel { get; set; }
        public LocationListViewModel LocationModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            InitializeRepositories();
            InitializeModels();
        }
        private void InitializeModels()
        {
            FilmModel = new FilmListViewModel(this);            
            PersonModel = new PersonListViewModel(this);           
            CountryModel = new CountryListViewModel(this);            
            LocationModel = new LocationListViewModel(this);            
        }

        private void InitializeRepositories()
        {
            if (_persist)
            {
                var context = new FilmContext();
                context.Films.AddRange(Infrastructure.ConcreteRepositories.SeedCollection._baseFilmList);
                context.People.AddRange(SeedCollection._basePersonList);
                context.Countries.AddRange(SeedCollection._baseCountryList);
                context.Locations.AddRange(SeedCollection._baseLocationList);
                CountryRepository = new Infrastructure.ConcreteRepositories.EntityFramework.EFCountryRepository(context);
                FilmCountryRepository = new EFFilmCountryRepository(context);
                FilmPersonRepository = new EFFilmPersonRepository(context);
                FilmRepository = new EFFilmRepository(context);
                LocationRepository = new EFLocationRepository(context);
                PersonRepository = new EFPersonRepository(context);
            }
            else
            {
                CountryRepository = new InMemoryCountryRepository(new List<Country>());
                CountryRepository.AddRange(SeedCollection._baseCountryList);
                FilmCountryRepository = new InMemoryFilmCountryRepository(new List<FilmCountry>());
                FilmPersonRepository = new InMemoryFilmPersonRepository(new List<FilmPerson>());
                FilmRepository = new InMemoryFilmRepository(new List<Film>());
                FilmRepository.AddRange(SeedCollection._baseFilmList);
                LocationRepository = new InMemoryLocationRepository(new List<Location>());
                LocationRepository.AddRange(SeedCollection._baseLocationList);
                PersonRepository = new InMemoryPersonRepository(new List<Person>());
                PersonRepository.AddRange(SeedCollection._basePersonList);
            };
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FilmPanel(object sender, RoutedEventArgs e)
        {
            FilmListView view = new FilmListView(this);
            view.ShowDialog();
        }

        private void PersonPanel(object sender, RoutedEventArgs e)
        {
            PersonListView view = new PersonListView(this);
            view.ShowDialog();
        }

        private void CountryPanel(object sender, RoutedEventArgs e)
        {
            CountryListView view = new CountryListView(this);
            view.ShowDialog();
        }

        private void LocationPanel(object sender, RoutedEventArgs e)
        {
            LocationListView view = new LocationListView(this);
            view.ShowDialog();
        }
    }
}
