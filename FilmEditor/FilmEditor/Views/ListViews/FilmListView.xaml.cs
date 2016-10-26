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

namespace FilmEditor.Views.ListViews
{
    /// <summary>
    /// Interaction logic for FilmListView.xaml
    /// </summary>
    public partial class FilmListView : Window
    { 
        private readonly MainWindow _mainView;
        public FilmListView(MainWindow view)
        {
            InitializeComponent();
            _mainView = view;
            Model = view.FilmModel;
            DataContext = Model;
            Owner = _mainView;
        }

        public FilmListViewModel Model
        {
            get { return (FilmListViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(FilmListViewModel), typeof(FilmListView), new PropertyMetadata(null));




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

        private void New(object sender, RoutedEventArgs e)
        {
            Model.New();
            Refresh();
        }

        private void Refresh()
        {
            this.Hide();
            this.Show();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            Model.Save();
            Refresh();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Model.Delete();
            Refresh();
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            Model.Update();
            Refresh();
        }

        private void AddActor(object sender, RoutedEventArgs e)
        {
            Model.AddContributor(Role.Actor);
        }

        private void AddComposer(object sender, RoutedEventArgs e)
        {
            Model.AddContributor(Role.Composer);
        }

        private void AddDirector(object sender, RoutedEventArgs e)
        {
            Model.AddContributor(Role.Director);
        }

        private void ShowActors(object sender, RoutedEventArgs e)
        {
            Model.ShowContributors(Role.Actor);
        }

        private void ShowComposers(object sender, RoutedEventArgs e)
        {
            Model.ShowContributors(Role.Composer);
        }

        private void ShoDirectors(object sender, RoutedEventArgs e)
        {
            Model.ShowContributors(Role.Director);
        }

        private void AddCountry(object sender, RoutedEventArgs e)
        {
            Model.Addountry();
        }

        private void ShowCountries(object sender, RoutedEventArgs e)
        {
            Model.ShowCountries();
        }

        private void SaveAll(object sender, RoutedEventArgs e)
        {
            Model.SaveAll();
        }

        private void ShowDetails(object sender, RoutedEventArgs e)
        {
            Model.ShowDetails();
        }
    }
}
