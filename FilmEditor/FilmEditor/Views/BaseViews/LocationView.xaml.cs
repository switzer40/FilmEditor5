using FilmEditor.ViewModels;
using FilmEditor.Core.Model;
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
    /// Interaction logic for LocationView.xaml
    /// </summary>
    public partial class LocationView : Window
    {
        public LocationView(LocationListViewModel model)
        {
            InitializeComponent();
            Model = model;
            Location = Model.CurrentLocation;
            DataContext = Location;
        }

        public bool Accept { get; set; }

        public LocationListViewModel Model
        {
            get { return (LocationListViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(LocationListViewModel), typeof(LocationView), new PropertyMetadata(null));



        public Location Location
        {
            get { return (Core.Model.Location)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Location.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LocationProperty =
            DependencyProperty.Register("Location", typeof(Location), typeof(LocationView), new PropertyMetadata(null));

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
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
