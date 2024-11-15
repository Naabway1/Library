using Library.Model;
using Library.View;
using MVVM;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;

namespace Library.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private Frame _myFrame;
        public Frame MyFrame
        {
            get => _myFrame;
            set
            {
                _myFrame = value;
                OnPropertyChanged();
            }
        }

        public ICommand NavCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand NavigateToAddBookPage { get; set; }
        public ICommand NavigateToMainBookPage { get; set; }

        private Book _selectedBook;
        private string _title;
        private string _author;
        private string _genre;
        private int _numberOfPages;
        private int _yearOfPublication;

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        public string Author
        {
            get => _author;
            set { _author = value; OnPropertyChanged(); }
        }

        public string Genre
        {
            get => _genre;
            set { _genre = value; OnPropertyChanged(); }
        }

        public int NumberOfPages
        {
            get => _numberOfPages;
            set { _numberOfPages = value; OnPropertyChanged(); }
        }

        public int YearOfPublication
        {
            get => _yearOfPublication;
            set { _yearOfPublication = value; OnPropertyChanged(); }
        }
        public MainFrame mainPage = new MainFrame();

        public ObservableCollection<Book> Books { get; set; }
        public MainViewModel()
        {
            Books = new ObservableCollection<Book>();
            NavigateToMainBookPage = new RelayCommand(param => MyFrame.Navigate(mainPage));
            NavCommand = new RelayCommand(param => MyFrame.Navigate(new AddUpdFrame { DataContext = this } ));
            AddCommand = new RelayCommand(param => AddBook());
            RemoveCommand = new RelayCommand(param => RemoveBook(), param => SelectedBook != null);
        }
        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }
        private void AddBook()
        {
            if (SelectedBook == null)
            {
                var newBook = new Book()
                {
                    Title = Title,
                    Author = Author,
                    Genre = Genre,
                    NumberOfPages = NumberOfPages,
                    YearOfPublication = YearOfPublication
                };

                Books.Add(newBook);

                Title = string.Empty;
                Author = string.Empty;
                Genre = string.Empty;
                NumberOfPages = 0;
                YearOfPublication = 0;
            }
            else if(SelectedBook != null)
            {
                var newBook = new Book()
                {
                    Title = SelectedBook.Title,
                    Author = SelectedBook.Author,
                    Genre = SelectedBook.Genre,
                    NumberOfPages = SelectedBook.NumberOfPages,
                    YearOfPublication = SelectedBook.YearOfPublication
                };

                Books.Add(newBook);
                Books.Remove(SelectedBook);
                SelectedBook = null;
            }
            MyFrame.GoBack();
        }
        private void RemoveBook()
        {
            if (SelectedBook != null)
            {
                Books.Remove(SelectedBook);
                SelectedBook = null;
            }
        }

        //реализация интерфейса IPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
 