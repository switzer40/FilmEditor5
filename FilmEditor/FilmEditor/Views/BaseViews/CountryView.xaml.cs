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
    /// Interaction logic for CountryView.xaml
    /// </summary>
    public partial class CountryView : Window
    {
        public CountryView(CountryListViewModel model)
        {
            InitializeComponent();
            Model = model;
            Country = Model.CurrentCountry;
            DataContext = Country;
            nameTextBox.Focus();
        }
        public bool Accept { get; set; }




        public CountryListViewModel Model
        {
            get { return (CountryListViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(CountryListViewModel), typeof(CountryView), new PropertyMetadata(null));




        public Country Country
        {
            get { return (Country)GetValue(CountryProperty); }
            set { SetValue(CountryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Country.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountryProperty =
            DependencyProperty.Register("Country", typeof(Country), typeof(CountryView), new PropertyMetadata(null));




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
