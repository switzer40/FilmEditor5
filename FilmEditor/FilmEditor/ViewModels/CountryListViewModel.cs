using System;
using System.Windows;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using FilmEditor.Infrastructure.ConcreteRepositories;
using FilmEditor.Core.Interfaces;
using FilmEditor.Core.Model;
using FilmEditor.Views.UtilityViews;
using FilmEditor.Views.BaseViews;
using FilmEditor.Core.Abstractions;

namespace FilmEditor.ViewModels
{
    public class CountryListViewModel : DependencyObject
    {

        private readonly AbstractCountryRepository _countryRepository;
        private readonly AbstractFilmCountryRepository _filmCountryRepository;
        private readonly AbstractFilmRepository _filmRepository;
        

        public CountryListViewModel(MainWindow view)
        {
            _countryRepository = view.CountryRepository;
            _filmCountryRepository = view.FilmCountryRepository;
            _filmRepository = view.FilmRepository;
            Countries = new ObservableCollection<Country>(_countryRepository.List());
            CurrentCountry = _countryRepository.List().FirstOrDefault();
        }

        public ObservableCollection<Country> Countries
        {
            get { return (ObservableCollection<Country>)GetValue(CountriesProperty); }
            set { SetValue(CountriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Countries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountriesProperty =
            DependencyProperty.Register("Countries", typeof(ObservableCollection<Country>), typeof(CountryListViewModel), new PropertyMetadata(null));



        public Country CurrentCountry
        {
            get { return (Country)GetValue(CurrentCountryProperty); }
            set { SetValue(CurrentCountryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentCountry.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentCountryProperty =
            DependencyProperty.Register("CurrentCountry", typeof(Country), typeof(CountryListViewModel), new PropertyMetadata(null));
        

        internal void Find()
        {
            StringDialog dialog = new StringDialog("A country abbreviation");
            dialog.ShowDialog();
            if (dialog.Accept)
            {
                string abbrev = dialog.YourString;
                CurrentCountry = _countryRepository.GetByAbbreviation(abbrev);
                CountryView view = new CountryView(this);
                view.ShowDialog();
            }
        }

        internal void Edit()
        {
            CountryView view = new CountryView(this);
            view.ShowDialog();
            CurrentCountry = view.Country;
        }

        internal void New()
        {
            CurrentCountry = new Country();
            CountryView view = new CountryView(this);
            view.ShowDialog();
            if (view.Accept)
            {
                Countries.Add(view.Country);
            }
        }

        internal void Save()
        {
            _countryRepository.Add(CurrentCountry);
        }

        internal void Delete()
        {
            _countryRepository.Delete(CurrentCountry);
            Countries.Remove(CurrentCountry);
            CurrentCountry = _countryRepository.List().FirstOrDefault();
        }

        internal void Update()
        {
            _countryRepository.Update(CurrentCountry);
        }

        internal void SaveAll()
        {
            _countryRepository.AddRange(Countries.ToList());
        }
    }
}
