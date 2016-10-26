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

namespace FilmEditor.Views.UtilityViews
{
    /// <summary>
    /// Interaction logic for FilmMessageBox.xaml
    /// </summary>
    public partial class FilmMessageBox : Window
    {
        public FilmMessageBox(string message)
        {
            InitializeComponent();
            Message = message;
            DataContext = this;
        }
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(FilmMessageBox), new PropertyMetadata(""));



        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
