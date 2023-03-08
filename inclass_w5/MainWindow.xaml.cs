using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public ObservableCollection<Book> books = null;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            books = new ObservableCollection<Book>();
            foreach (var line in File.ReadAllLines("data/book_data.csv")) {
                var element = line.Split(",");
                books.Add(new Book()
                {
                    coverImage = element[0],
                    title = element[1],
                    publishedYear = int.Parse(element[2]),
                    author = element[3]
                });
            }
            bookListView.ItemsSource = books;
            bookListView.SelectedIndex = 0;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            books.Add(new Book()
            {
                title = "Nha gia kim",
                coverImage = "img/nhagiakim.jpg",
                publishedYear = 1988,
                author = "Paulo Coelho"
            });
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int i = bookListView.SelectedIndex;
            books.RemoveAt(i);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            int i = bookListView.SelectedIndex;
            books[i].title = "Nha Gia Kim";
            books[i].author = "Paulo Coelho";
            books[i].coverImage = "img/dacnhantam.jpg";
            books[i].publishedYear = 1988;
        }

        private void booksListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int i = booksComboBox.SelectedIndex;
            MessageBox.Show("Tiêu đề: "  + books[i].title
                +"\nTác giả:" + books[i].author + "\n"
                +"Năm xuất bản:" + books[i].publishedYear);
        }
    }
}
