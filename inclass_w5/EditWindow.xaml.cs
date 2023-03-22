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

namespace inclass_w5
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public Book books;
        public EditWindow()
        {
            InitializeComponent();
            DataContext = books;
        }

        public void setBook(Book b)
        {
            books = b;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = books;
        }

        private void browseImage(object sender, RoutedEventArgs e)
        {

        }

        private void saveBookInfo(object sender, RoutedEventArgs e)
        {

        }
    }
}
