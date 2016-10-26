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

namespace FilmEditor.Views.SpecialViews
{
    /// <summary>
    /// Interaction logic for FilmDetailView.xaml
    /// </summary>
    public partial class FilmDetailView : Window
    {
        public FilmDetailView(FilmDetailViewModel model)
        {
            InitializeComponent();
            Model = model;
            DataContext = Model;
        }
        public FilmDetailViewModel Model
        {
            get { return (FilmDetailViewModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Model.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(FilmDetailViewModel), typeof(FilmDetailView), new PropertyMetadata(null));







        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
