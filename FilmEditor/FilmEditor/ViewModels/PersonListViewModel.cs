using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FilmEditor.Core.Interfaces;
using System.Windows;
using FilmEditor.Core.Model;
using FilmEditor.Views.BaseViews;
using FilmEditor.Views.UtilityViews;
using FilmEditor.Core.Abstractions;

namespace FilmEditor.ViewModels
{
    public class PersonListViewModel : DependencyObject
    {
        private readonly AbstractFilmPersonRepository _filmPersonRepository;
        private readonly AbstractFilmRepository _filmRepository;
        private readonly AbstractPersonRepository _personRepository;
        

        public PersonListViewModel(MainWindow view)
        {
            _personRepository = view.PersonRepository;
            People = new ObservableCollection<Person>(_personRepository.List());
            CurrentPerson = _personRepository.List().FirstOrDefault();
        }

        public ObservableCollection<Person> People
        {
            get { return (ObservableCollection<Person>)GetValue(PeopleProperty); }
            set { SetValue(PeopleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for People.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PeopleProperty =
            DependencyProperty.Register("People", typeof(ObservableCollection<Person>), typeof(PersonListViewModel), new PropertyMetadata(null));



        public Person CurrentPerson
        {
            get { return (Person)GetValue(CurrentPersonProperty); }
            set { SetValue(CurrentPersonProperty, value); }
        }

        internal void Find()
        {
            Person foundPerson = null;
            StringDialog dialog = new StringDialog("A partial last name");
            dialog.ShowDialog();
            if (dialog.Accept)
            {
                string lastName = dialog.YourString;
                List<Person> candidates = _personRepository.ListByLastName(lastName);
                switch (candidates.Count)
                {
                    case 0:
                        ReportIt("No person has last name " + lastName);
                        return;
                    case 1:
                        foundPerson = candidates[0];
                        break;
                    default:
                        foundPerson = ChooseAUniquePerson(candidates);
                        break;
                }
                PersonView view = new PersonView(this);
                view.Show();
            }
        }
        private Person ChooseAUniquePerson(List<Person> candidates)
        {
            Person result = null;
            List<string> fullNames = new List<string>();
            foreach (Person p in candidates) fullNames.Add(p.FullName);
            StringChooser chooser = new StringChooser(fullNames);
            chooser.Show();
            if (chooser.Accept) result = _personRepository.GetByFullName(chooser.ChosenString);
            return result;
        }

        internal void SaveAll()
        {
            _personRepository.AddRange(People.ToList());
        }

        // Using a DependencyProperty as the backing store for CurrentPerson.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPersonProperty =
            DependencyProperty.Register("CurrentPerson", typeof(Person), typeof(PersonListViewModel), new PropertyMetadata(null));
        private MainWindow mainWindow;

        internal void Edit()
        {
            PersonView view = new PersonView(this);
            view.ShowDialog();
            if (view.Accept)
            {
                CurrentPerson = view.Person;
            }
        }

        internal void ShowContributions(Role role)
        {
            AbstractFilmPersonRepository fpRepo = _filmPersonRepository;
            AbstractFilmRepository fRepo = _filmRepository;
            List<Guid> ids = fpRepo.ListFilmIdsForPersonIdAndRole(CurrentPerson.Id, role);
            List<string> titles = new List<string>();
            foreach (Guid id in ids)
            {
                Film f = fRepo.GetById(id);
                titles.Add(f.Title);
            }
            if (titles.Count > 0)
            {
                StringChooser chooser = new StringChooser(titles);
                chooser.ShowDialog();
            }
            else
            {
                string[] actions = { " contributes to", " acts in", " composes for", " directs" };
                string action = actions[(int)role];
                ReportIt("As yet " + CurrentPerson.FullName + action + " no film");
            }
        }

        private void ReportIt(string message)
        {
            FilmMessageBox box = new FilmMessageBox(message);
            box.Show();
        }

        internal void New()
        {
            CurrentPerson = new Person();
            PersonView view = new PersonView(this);
            view.ShowDialog();
            People.Add(view.Person);
            CurrentPerson = view.Person;
        }

        internal void Save()
        {
            _personRepository.Add(CurrentPerson);
        }

        internal void Delete()
        {
            _personRepository.Delete(CurrentPerson);
            CurrentPerson = _personRepository.List().FirstOrDefault();
        }

        internal void Update()
        {
            _personRepository.Update(CurrentPerson);
        }
    }
}
