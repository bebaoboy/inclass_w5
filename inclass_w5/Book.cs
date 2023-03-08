using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inclass_w5 { 
    public class Book :INotifyPropertyChanged
    {
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


        public event PropertyChangedEventHandler? PropertyChanged;
        
    }
}
