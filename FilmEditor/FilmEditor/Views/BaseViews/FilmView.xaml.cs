using FilmEditor.Core.Abstractions;
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

namespace FilmEditor.Views.BaseViews
{
    /// <summary>
    /// Interaction logic for FilmView.xaml
    /// </summary>
    public partial class FilmView : Window
    {
       
        public FilmView(FilmListViewModel model)
        {
            InitializeComponent();
            Model = model;
            Film = Model.CurrentFilm;
            DataContext = Film;
            barcodeTextBox.Focus();
        }

        public bool Accept;





        public FilmListViewModel Model
        {
            get { return (FilmListViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(FilmListViewModel), typeof(FilmView), new PropertyMetadata(null));





        public Film Film
        {
            get { return (Film)GetValue(FilmProperty); }
            set { SetValue(FilmProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Film.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilmProperty =
            DependencyProperty.Register("Film", typeof(Film), typeof(FilmView), new PropertyMetadata(null));
        private Film currentFilm;

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SetLocation(object sender, RoutedEventArgs e)
        {
            Model.SetLocation();
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
