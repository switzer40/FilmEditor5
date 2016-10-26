using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FilmEditor.Views.UtilityViews
{
    /// <summary>
    /// Interaction logic for StringChooser.xaml
    /// </summary>
    public partial class StringChooser : Window
    {
        public StringChooser(List<string> choices)
        {
            InitializeComponent();
            Choices = new ObservableCollection<string>(choices);
            ChosenString = Choices.FirstOrDefault();
            DataContext = this;
        }
        public bool Accept { get; set; }


        public ObservableCollection<string> Choices
        {
            get { return (ObservableCollection<string>)GetValue(ChoicesProperty); }
            set { SetValue(ChoicesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Choices.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChoicesProperty =
            DependencyProperty.Register("Choices", typeof(ObservableCollection<string>), typeof(StringChooser), new PropertyMetadata(null));



        public string ChosenString
        {
            get { return (string)GetValue(ChosenStringProperty); }
            set { SetValue(ChosenStringProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChosenString.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChosenStringProperty =
            DependencyProperty.Register("ChosenString", typeof(string), typeof(StringChooser), new PropertyMetadata(""));



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

        private void stringChooserListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChosenString = e.AddedItems[0] as string;
        }
      
    }
}
