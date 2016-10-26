using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FilmEditor.Core.Model;
using FilmEditor.Core.Abstractions;

namespace FilmEditor.ViewModels
{
    public class FilmDetailViewModel : DependencyObject
    {
        private readonly MainWindow _view;
        public FilmDetailViewModel(MainWindow view)
        {
            _view = view;
        }
        public Film Film
        {
            get { return (Film)GetValue(FilmProperty); }
            set { SetValue(FilmProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Film.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilmProperty =
            DependencyProperty.Register("Film", typeof(Film), typeof(FilmDetailViewModel), new PropertyMetadata(null));



        private void InitializeProperties()
        {
            Actors = new ObservableCollection<Person>(GetContributors(Role.Actor));
            Composers = new ObservableCollection<Person>(GetContributors(Role.Composer));
            Directors = new ObservableCollection<Person>(GetContributors(Role.Director));
            Countries = new ObservableCollection<Country>(GetCountries());
            CurrentActor = Actors.FirstOrDefault();
            CurrentComposer = Composers.FirstOrDefault();
            CurrentDirecor = Directors.FirstOrDefault();
            CurrentCountry = Countries.FirstOrDefault();
        }

        private List<Country> GetCountries()
        {
            List<Country> result = new List<Country>();
            AbstractFilmCountryRepository fcRepo = _view.FilmCountryRepository;
            AbstractCountryRepository cRepo = _view.CountryRepository;
            List<Guid> ids = fcRepo.ListCountryIdsForFilmId(Film.Id);
            foreach (Guid id in ids)
            {
                Country c = cRepo.GetById(id);
                result.Add(c);
            }
            return result;
        }

        private List<Person> GetContributors(Role role)
        {
            List<Person> result = new List<Person>();
            AbstractFilmPersonRepository fpRepo = _view.FilmPersonRepository;
            AbstractPersonRepository pRepo = _view.PersonRepository;
            List<Guid> ids = fpRepo.ListPersonIdsForilmIdAndRole(Film.Id, role);
            foreach (Guid id in ids)
            {
                Person p = pRepo.GetById(id);
                result.Add(p);
            }
            return result;
        }

        public ObservableCollection<Person> Actors
        {
            get { return (ObservableCollection<Person>)GetValue(ActorsProperty); }
            set { SetValue(ActorsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Actors.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActorsProperty =
            DependencyProperty.Register("Actors", typeof(ObservableCollection<Person>), typeof(FilmDetailViewModel), new PropertyMetadata(null));



        public ObservableCollection<Person> Composers
        {
            get { return (ObservableCollection<Person>)GetValue(ComposersProperty); }
            set { SetValue(ComposersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Composers.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ComposersProperty =
            DependencyProperty.Register("Composers", typeof(ObservableCollection<Person>), typeof(FilmDetailViewModel), new PropertyMetadata(null));



        public ObservableCollection<Person> Directors
        {
            get { return (ObservableCollection<Person>)GetValue(DirectorsProperty); }
            set { SetValue(DirectorsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Directors.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DirectorsProperty =
            DependencyProperty.Register("Directors", typeof(ObservableCollection<Person>), typeof(FilmDetailViewModel), new PropertyMetadata(null));



        public Person CurrentActor
        {
            get { return (Person)GetValue(CurrentActorProperty); }
            set { SetValue(CurrentActorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentActor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentActorProperty =
            DependencyProperty.Register("CurrentActor", typeof(Person), typeof(FilmDetailViewModel), new PropertyMetadata(null));



        public Person CurrentComposer
        {
            get { return (Person)GetValue(CurrentComposerProperty); }
            set { SetValue(CurrentComposerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentComposer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentComposerProperty =
            DependencyProperty.Register("CurrentComposer", typeof(Person), typeof(FilmDetailViewModel), new PropertyMetadata(null));



        public Person CurrentDirecor
        {
            get { return (Person)GetValue(CurrentDirecorProperty); }
            set { SetValue(CurrentDirecorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentDirecor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentDirecorProperty =
            DependencyProperty.Register("CurrentDirecor", typeof(Person), typeof(FilmDetailViewModel), new PropertyMetadata(null));




        public ObservableCollection<Country> Countries
        {
            get { return (ObservableCollection<Country>)GetValue(CountriesProperty); }
            set { SetValue(CountriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Countries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountriesProperty =
            DependencyProperty.Register("Countries", typeof(ObservableCollection<Country>), typeof(FilmDetailViewModel), new PropertyMetadata(null));



        public Country CurrentCountry
        {
            get { return (Country)GetValue(CurrentCountryProperty); }
            set { SetValue(CurrentCountryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentCountry.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentCountryProperty =
            DependencyProperty.Register("CurrentCountry", typeof(Country), typeof(FilmDetailViewModel), new PropertyMetadata(null));



    }
}
