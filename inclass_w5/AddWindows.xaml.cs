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
    /// Interaction logic for AddWindows.xaml
    /// </summary>
    public partial class AddWindows : Window
    {

        public Book CurrentBook;
        public Book ReturnBook;
        public AddWindows(Book book)
        {
            InitializeComponent();
            CurrentBook = book;
        }

        private void chooseImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile= new OpenFileDialog();
            openFile.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *png)|*.jpg; *.jpeg; *.gif; *.bmp; *png";
            openFile.Multiselect= false;
            if(openFile.ShowDialog() == true)
            {
                var fileName = openFile.FileName.Split("\\").Last();

                try
                {
                    File.Copy(openFile.FileName, "./img/" + fileName, true);
                }
                catch (Exception ex)
                {

                }
                CurrentBook.coverImage = "./img/" + fileName;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = CurrentBook;
        }

        private void SaveBook(object sender, RoutedEventArgs e)
        {
            string titlebook = title.Text;
            string authorbook = author.Text;
            int publishedYearbook = int.Parse(publish_year.Text);
            string coverImagebook = imageBox.Source.ToString();
            coverImagebook = "./img/" + coverImagebook.Split('/').Last();
            ReturnBook = new Book()
            {
                title = titlebook,
                author = authorbook,
                publishedYear = publishedYearbook,
                coverImage = coverImagebook,
            };
            DialogResult = true;
        }
    }
}
