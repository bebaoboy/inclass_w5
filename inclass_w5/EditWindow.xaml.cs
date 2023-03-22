using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        private FileInfo _selectedImage = null;
        private MainWindow main;
        public EditWindow(MainWindow m)
        {
            InitializeComponent();
            DataContext = books;
            main = m;
        }

        public void setBook(Book b)
        {
            books = b;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = books;
        }

        private void saveBookInfo(object sender, RoutedEventArgs e)
        {
            int i = 1990;
            if (int.TryParse(bookYear.Text, out int year)) {
                i = year;
            }
            main.setUpdatedBook(new Book() { title = bookName.Text, author = bookAuthor.Text, coverImage = books.coverImage, publishedYear = i }) ;
        }

        private void browseImage(object sender, RoutedEventArgs e)
        {
            var browseDiaglog = new OpenFileDialog();
            browseDiaglog.Multiselect = false;
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            browseDiaglog.InitialDirectory = folder;
            if (browseDiaglog.ShowDialog() == true)
            {
                _selectedImage = new FileInfo(browseDiaglog.FileName);
                if (_selectedImage != null )
                {
                    books.coverImage = _selectedImage.Directory.Name + "/" + _selectedImage.Name;
                }
            }
        }
    }
}