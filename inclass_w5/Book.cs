using System.ComponentModel;

namespace inclass_w5
{
    public class Book :INotifyPropertyChanged
    {
        private int _id = 1;
        public int id
        {
            get; set;
        }
        private string _title;
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(title)));

            }
        }
        private string _coverImage;
        public string coverImage
        {
            get
            {
                return _coverImage;
            }
            set
            {
                _coverImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(coverImage)));

            }
        }
        private string _author;
        public string author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(author)));

            }
        }
        private int _publishedYear;
        public int publishedYear
        {
            get { return _publishedYear; }
            set
            {
                _publishedYear = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(author)));

            }
        }

        public Book Clone()
        {
            var temp_book = new Book()
            {
                _id = this._id,
                title = this._title,
                author = this._author,
                publishedYear = this._publishedYear,
                coverImage = this._coverImage
            };
            return temp_book;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        
    }
}
