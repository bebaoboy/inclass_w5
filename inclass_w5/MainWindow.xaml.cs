using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

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
        private EditWindow editor;

        string username = "root";
        string password = "root";
        String dbName = "BookDb";

        string connectionString;
        SqlConnection _connection;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //books = new ObservableCollection<Book>();
            //foreach (var line in File.ReadAllLines("data/book_data.csv")) {
            //    var element = line.Split(",");
            //    books.Add(new Book()
            //    {
            //        coverImage = element[0],
            //        title = element[1],
            //        publishedYear = int.Parse(element[2]),
            //        author = element[3]
            //    });
            //}
            //bookListView.ItemsSource = books;
            //bookListView.SelectedIndex = 0;
            //connectionString = $"""
            //    Server = .\sqlexpress;
            //    User ID = {username}; Password={password};
            //    Database = RawDemo;
            //    TrustServerCertificate=True
            //    """;
            connectionString = new StringBuilder()
                .Append("Server = .\\sqlexpress;")
                .Append("User ID = ")
                .Append(username).Append(';')
                .Append("; Password=")
                .Append(password).Append(';')
                .Append("Database = ")
                .Append(dbName).Append(';')
                .Append("TrustServerCertificate=True")
                .ToString();
            _connection = new SqlConnection(connectionString);

            Title = "Database not connect!";
            try
            {
                _connection.Open();
                Title = "Database is ready!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Cannot connect to database. Reason: {ex.Message}");
            }
            books = new ObservableCollection<Book>(readFromDatabase());
            bookListView.ItemsSource = books;
            bookListView.SelectedIndex = 0;
        }

        private List<Book> readFromDatabase(int bookId=-1)
        {
            string sql;
            SqlCommand command;
            if (bookId != -1)
            {
                sql = "select * from Book where id = @id";
                command = new SqlCommand(sql, _connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = bookId;
            }
            else
            {
                sql =
                    "select id, title, cover from Book";
                command = new SqlCommand(sql, _connection);
            }


            using (var reader = command.ExecuteReader())
            {
                var temp = new List<Book>();
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string title = (string)reader["title"];
                    string name;
                    int year;
                    try
                    {
                        name = (string)reader["author"]; year = (int)reader["year"];
                    }
                    catch(Exception)
                    {
                        name = ""; year = 0;
                    }
                    string cover = (string)reader["cover"];

                    //Console.WriteLine($"{title} - {name}");
                    temp.Add(new Book()
                    {
                        id = id,
                        title = title,
                        coverImage = cover,
                        publishedYear = year,
                        author = name
                    });
                }
                return temp;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            var demoBook = new Book()
            {
                title = "2.0 Nha gia kim",
                coverImage = "img/nhagiakim.jpg",
                publishedYear = 2022,
                author = "Paulo Coelho"
            };

            var screen = new AddWindows(demoBook.Clone(), this);

            if (screen.ShowDialog() == true)
            {
                books.Add(screen.ReturnBook);
            }
            //screen.Show();

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            int i = bookListView.SelectedIndex;
            if (i == -1) return;
            string sql = "delete from book where id = @id";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = books[i].id;

            int rows = command.ExecuteNonQuery();

            if (rows > 0)
            {
                MessageBox.Show($"Book {books[i].title} is deleted");
            }
            books.RemoveAt(i);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            int i = bookListView.SelectedIndex;
            if (i == -1) return;
            editor = new EditWindow(this);
            if (books[i].publishedYear == 0 || books[i].author.Length == 0)
            {
                var temp = readFromDatabase(books[i].id);
                if (temp.Count > 0) books[i] = temp[0];
            }
            editor.setBook(books[i], i);
            editor.Show();
            //books[i].title = "Nha Gia Kim";
            //books[i].author = "Paulo Coelho";
            //books[i].coverImage = "img/dacnhantam.jpg";
            //books[i].publishedYear = 1988;
        }

        private void showDetail(int i)
        {
            if (books[i].publishedYear == 0 || books[i].author.Length == 0)
            {
                var temp = readFromDatabase(books[i].id);
                if (temp.Count > 0) books[i] = temp[0];
            }
            MessageBox.Show("Tiêu đề: " + books[i].title
                + "\nTác giả:" + books[i].author + "\n"
                + "Năm xuất bản:" + books[i].publishedYear);
        }

        private void booksListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int i = bookListView.SelectedIndex;
            showDetail(i);
        }

        private void editMenu_Click(object sender, RoutedEventArgs e)
        {
            updateButton_Click(sender, e);
        }

        private void deleteMenu_Click(object sender, RoutedEventArgs e)
        {
            deleteButton_Click(sender, e);
        }

        private void viewdetailMenu_Click(object sender, RoutedEventArgs e)
        {
            int i = bookListView.SelectedIndex;
            showDetail(i);
        }

        public void setUpdatedBook(Book b, int i)
        {
            books[i] = b;
            string sql = "update book set title=@title, author=@author, year=@year, cover=@cover where id=@id";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = b.id;
            command.Parameters.Add("@title", SqlDbType.NVarChar).Value = b.title;
            command.Parameters.Add("@author", SqlDbType.NVarChar).Value = b.author;
            command.Parameters.Add("@year", SqlDbType.Int).Value = b.publishedYear;
            command.Parameters.Add("@cover", SqlDbType.NVarChar).Value = b.coverImage;

            int rows = command.ExecuteNonQuery();

            if (rows > 0)
            {
                MessageBox.Show($"Book {b.title} is updated");
            }
        }

        public void setInsertBook(Book b)
        {
            string sql = "insert into book values(@title, @author, @year, @cover)";
            var command = new SqlCommand(sql, _connection);
            command.Parameters.Add("@title", SqlDbType.NVarChar).Value = b.title;
            command.Parameters.Add("@author", SqlDbType.NVarChar).Value = b.author;
            command.Parameters.Add("@year", SqlDbType.Int).Value = b.publishedYear;
            command.Parameters.Add("@cover", SqlDbType.NVarChar).Value = b.coverImage;

            try
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Last().id = (int)reader["id"];
                        MessageBox.Show($"Book {b.title} is added");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Book {b.title} is NOT added\n" + e.ToString());
            }
        }
    }
}
