using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmEditor.Core.Model;
using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Abstractions;
using FilmEditor.Views.BaseViews;
using FilmEditor.Views.UtilityViews;
using FilmEditor.Views.SpecialViews;
using FilmEditor.Infrastructure.ConcreteRepositories.EntityFramework;

namespace FilmEditor.ViewModels
{
    public class FilmListViewModel : DependencyObject
    {
        private readonly AbstractCountryRepository _countryRepository;
        private readonly AbstractFilmCountryRepository _filmCountryRepository;
        private readonly AbstractFilmPersonRepository _filmPersonRepository;
        private readonly AbstractFilmRepository _filmRepository;
        private readonly AbstractLocationRepository _locationRepository;
        private readonly AbstractPersonRepository _personRepository;
        private readonly MainWindow _mainView;

        public FilmListViewModel(MainWindow view)
        {
            _mainView = view;
            _countryRepository = view.CountryRepository;
            _filmCountryRepository = view.FilmCountryRepository;
            _filmPersonRepository = view.FilmPersonRepository;
            _filmRepository = view.FilmRepository;
            _locationRepository = view.LocationRepository;
            _personRepository = view.PersonRepository;
            Films = new ObservableCollection<Film>(_filmRepository.List());
            CurrentFilm = _filmRepository.List().FirstOrDefault();
        }

        public ObservableCollection<Film> Films
        {
            get { return (ObservableCollection<Film>)GetValue(FilmsProperty); }
            set { SetValue(FilmsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Films.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilmsProperty =
            DependencyProperty.Register("Films", typeof(ObservableCollection<Film>), typeof(FilmListViewModel), new PropertyMetadata(null));





        public Film CurrentFilm
        {
            get { return (Film)GetValue(CurrentFilmProperty); }
            set { SetValue(CurrentFilmProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentFilm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentFilmProperty =
            DependencyProperty.Register("CurrentFilm", typeof(Film), typeof(FilmListViewModel), new PropertyMetadata(null));




        public FilmListViewModel Model
        {
            get { return (FilmListViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(FilmListViewModel), typeof(FilmListViewModel), new PropertyMetadata(null));
        private MainWindow mainWindow;

        internal void SetLocation()
        {
            List<string> descriptions = new List<string>();
            foreach (Location l in _locationRepository.List())
                descriptions.Add(l.Description);
            StringChooser chooser = new StringChooser(descriptions);
            chooser.ShowDialog();
            if(chooser.Accept)
            {
                string description = chooser.ChosenString;
                Location loc = _locationRepository.GetByDescription(description);
                CurrentFilm.Location = loc;
            }
        }



        
        internal void Find()
        {
            FilmDialog dialog = new FilmDialog();
            dialog.ShowDialog();
            if (dialog.Accept)
            {
                string title = dialog.FilmTitle;
                CurrentFilm = _filmRepository.GetFilmByTitleAndType(title,dialog.Bluray);
                FilmView view = new FilmView(this);
                view.ShowDialog();
            }
        }

        internal void Edit()
        {
            FilmView view = new FilmView(this);
            view.ShowDialog();
            CurrentFilm = view.Film;
        }

        internal void New()
        {

            CurrentFilm = new Film();
            FilmView view = new FilmView(this);
            view.ShowDialog();
            if (view.Accept)
            {
                Films.Add(CurrentFilm);
            }
        }

        internal void Save()
        {
            _filmRepository.Add(CurrentFilm);
        }

        internal void Delete()
        {
            _filmRepository.Delete(CurrentFilm);
            Films.Remove(CurrentFilm);
            CurrentFilm = _filmRepository.List().FirstOrDefault();
        }

        internal void Update()
        {
            _filmRepository.Update(CurrentFilm);
        }

        internal void AddContributor(Role role)
        {
            StringDialog dialog = new StringDialog("A partial last name");
            dialog.ShowDialog();
            if (dialog.Accept)
            {

                string lastName = dialog.YourString;
                if (lastName == "")
                {
                    ReportIt("You must enter a nonempty last name");
                    return;
                }
                Person p = GetPersonFor(lastName);
                if (p == null) return;
                FilmPerson fp = new FilmPerson();
                fp.FilmId = CurrentFilm.Id;
                fp.PersonId = p.Id;
                fp.Roles.Add(role);                
                _filmPersonRepository.Add(fp);
            }
        }

        internal void ShowDetails()
        {
            if (CheckForMissingInfo())
            {
                FilmDetailViewModel model = new FilmDetailViewModel(_mainView);
                FilmDetailView view = new FilmDetailView(model);
                view.Show();
            }
        }

        private bool CheckForMissingInfo()
        {
            bool result = true;
            Guid id = CurrentFilm.Id;
            AbstractFilmPersonRepository fpRepo = _filmPersonRepository;
            AbstractFilmCountryRepository fcRepo = _filmCountryRepository;
            List<Guid> ids = fpRepo.ListPersonIdsForilmIdAndRole(id, Role.Actor);
            int actorCount = ids.Count;
            ids = fpRepo.ListPersonIdsForilmIdAndRole(id, Role.Composer);
            int composerCount = ids.Count;
            ids = fpRepo.ListPersonIdsForilmIdAndRole(id, Role.Director);
            int directorCount = ids.Count;
            ids = fcRepo.ListCountryIdsForFilmId(id);
            int countryCount = ids.Count;
            if (actorCount == 0)
            {
                ReportIt(CurrentFilm.Title + " has no actors.");
                result = false;
            }
            if (composerCount == 0)
            {
                ReportIt(CurrentFilm.Title + " has no composers.");
                result = false;
            }
            if (directorCount == 0)
            {
                ReportIt(CurrentFilm.Title + " has no directors.");
                result = false;
            }
            if (countryCount == 0)
            {
                ReportIt(CurrentFilm.Title + " has no countries.");
                result = false;
            }
            if (CurrentFilm.Location == null)
            {
                ReportIt(CurrentFilm.Title + "has no location");
                result = false;
            }
            return result;

        }

        internal void SaveAll()
        {
            _filmRepository.AddRange(Films.ToList());
        }

        internal void ShowCountries()
        {
            AbstractFilmCountryRepository fcRepo = _filmCountryRepository;
            AbstractCountryRepository cRepo = _countryRepository;
            List<Guid> ids = fcRepo.ListCountryIdsForFilmId(CurrentFilm.Id);
            List<string> names = new List<string>();
            foreach (Guid id in ids)
            {
                Country c = cRepo.GetById(id);
                names.Add(c.Name);
            }
            if (names.Count > 0)
            {
                StringChooser chooser = new StringChooser(names);
                chooser.Show();
            }
            else
                ReportIt("No countries are defined for " + CurrentFilm.Title);
        }

        internal void Addountry()
        {
            StringDialog dialog = new StringDialog("A country abbreviation");
            dialog.ShowDialog();
            if (dialog.Accept)
            {
                string abbreviation = dialog.YourString;
                AbstractCountryRepository cRepo = _countryRepository;
                Country c = cRepo.GetByAbbreviation(abbreviation);
                FilmCountry fc = new FilmCountry();
                fc.FilmId = CurrentFilm.Id;
                fc.CountryId = c.Id;
                AbstractFilmCountryRepository fcRepo = _filmCountryRepository;
                fcRepo.Add(fc);
            }
        }

        private void ReportIt(string message)
        {
            FilmMessageBox box = new FilmMessageBox(message);
            box.Show();
        }

        private Person GetPersonFor(string lastName)
        {
            Person result = null;
            AbstractPersonRepository pRepo = _personRepository;
            List<Person> candidates = pRepo.ListByLastName(lastName);
            switch (candidates.Count)
            {
                case 0:
                    ReportIt("No known person has a laast name containing " + lastName);
                    break;
                case 1:
                    result = candidates[0];
                    break;
                default:
                    result = ChooseAUniquePerson(candidates, pRepo);
                    break;
            }
            return result;
        }

        private Person ChooseAUniquePerson(List<Person> candidates, AbstractPersonRepository pRepo)
        {
            Person result = null;
            List<string> fullNames = new List<string>();
            foreach (Person p in candidates) fullNames.Add(p.FullName);
            StringChooser chooser = new StringChooser(fullNames);
            chooser.ShowDialog();
            if (chooser.Accept) result = pRepo.GetByFullName(chooser.ChosenString);
            return result;
        }

        internal void ShowContributors(Role role)
        {
            AbstractPersonRepository pRepo = _personRepository;
            AbstractFilmPersonRepository fpRepo = _filmPersonRepository;               
            List<Guid> ids = fpRepo.ListPersonIdsForilmIdAndRole(CurrentFilm.Id, role);
            List<string> names = new List<string>();
            foreach (Guid id in ids)
            {
                Person p = pRepo.GetById(id);
                names.Add(p.FullName);
            }
            if (names.Count > 0)
            {
                StringChooser chooser = new StringChooser(names);
                chooser.Show();
            }
            else
            {
                string[] contribkind = { "contributors", "actors", "composers", "directors", "scriptwriters" };

                string kind = contribkind[(int)role];

                ReportIt("There are (as yet) no " + kind + " defined for this film");
            }

        }
    }
}
