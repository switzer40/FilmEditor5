using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmEditor.Core.Abstractions;
using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Model;
using FilmEditor.Views.UtilityViews;
using FilmEditor.Views.BaseViews;
using FilmEditor.Infrastructure.ConcreteRepositories.EntityFramework;

namespace FilmEditor.ViewModels
{
    public class LocationListViewModel : DependencyObject
    {
        
        private readonly AbstractLocationRepository _locationRepository;
        private readonly AbstractFilmRepository _filmRepository;

        public LocationListViewModel(MainWindow view)
        {
            _locationRepository = view.LocationRepository;
            _filmRepository = view.FilmRepository;
            Locations = new ObservableCollection<Location>(_locationRepository.List());
            CurrentLocation = _locationRepository.List().FirstOrDefault();
        }

        public ObservableCollection<Location> Locations
        {
            get { return (ObservableCollection<Location>)GetValue(LocationsProperty); }
            set { SetValue(LocationsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Locations.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LocationsProperty =
            DependencyProperty.Register("Locations", typeof(ObservableCollection<Location>), typeof(LocationListViewModel), new PropertyMetadata(null));





        public Location CurrentLocation
        {
            get { return (Location)GetValue(CurrentLocationProperty); }
            set { SetValue(CurrentLocationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentLocation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentLocationProperty =
            DependencyProperty.Register("CurrentLocation", typeof(Location), typeof(LocationListViewModel), new PropertyMetadata(null));
        
        internal void Find()
        {
            StringDialog dialog = new StringDialog("A partial description");
            dialog.ShowDialog();
            if (dialog.Accept)
            {
                string description = dialog.YourString;
                AbstractLocationRepository lRepo = _locationRepository;
                Location loc = null;
                try
                {
                    loc = lRepo.GetByDescription(description);
                }
                catch (Exception ex)
                {
                    ReportIt("The description must specify a unique location");
                }
                if (loc != null)
                {
                    LocationView view = new LocationView(this);
                    view.ShowDialog();
                }

            }
        }

        internal void SaveAll()
        {
            _locationRepository.AddRange(Locations.ToList());
        }

        private void ReportIt(string message)
        {
            FilmMessageBox box = new FilmMessageBox(message);
            box.ShowDialog();
        }

        internal void Edit()
        {
            LocationView view = new LocationView(this);
            view.ShowDialog();
            CurrentLocation = view.Location;
            Locations.Add(CurrentLocation);
        }

        internal void New()
        {
            CurrentLocation = new Location();
            Edit();
        }

        internal void Save()
        {
            _locationRepository.Add(CurrentLocation);
        }

        internal void Delete()
        {
            _locationRepository.Delete(CurrentLocation);
            CurrentLocation = _locationRepository.List().FirstOrDefault();
        }

        internal void Update()
        {
            _locationRepository.Update(CurrentLocation);
        }

        internal void StoredFilms()
        {
            List<string> titles = new List<string>();
            AbstractFilmRepository fRepo = _filmRepository;
            foreach (Film f in fRepo.List())
                if (f.Location.Id.Equals(CurrentLocation.Id)) titles.Add(f.Title);

            if (titles.Count > 0)
            {
                StringChooser chooser = new StringChooser(titles);
                chooser.ShowDialog();
            }
            else ReportIt("There are no films stored in this location");

        }
    }
}
