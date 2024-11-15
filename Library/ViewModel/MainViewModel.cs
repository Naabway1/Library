using Library.Model;
using Library.View;
using MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Library.ViewModel
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private Book _selectedBook;
        public ICommand NavCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public Action NavigateToAddBookPage { get; set; }
        public Action NavigateToMainBookPage { get; set; }
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

        public ObservableCollection<Book> Books { get; set; }
        public MainViewModel()
        {
            NavigateToMainBookPage?.Invoke();
            Books = new ObservableCollection<Book>
            {
                new Book() {Title = "Pizdec", Author = "Ahuet' Vladimirovi4", Genre = "Famtosia", NumberOfPages = 256, YearOfPublication = 2024}
            };

            NavCommand = new RelayCommand(param => Nav());
            AddCommand = new RelayCommand(param => AddBook());
            RemoveCommand = new RelayCommand(param => RemoveBook(), param => SelectedBook != null);
            UpdateCommand = new RelayCommand(param => UpdateBook(), param => param is Book);
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
        private void Nav()
        {
            NavigateToAddBookPage?.Invoke(); // Вызываем делегат для перехода на страницу
        }
        private void AddBook()
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
        private void RemoveBook()
        {
            if (SelectedBook != null)
            {
                Books.Remove(SelectedBook);
                SelectedBook = null;
            }
        }
        private void UpdateBook()
        {
            if (SelectedBook != null)
            {
                SelectedBook.Title = Title;
                SelectedBook.Author = Author;
                SelectedBook.Genre = Genre;
                SelectedBook.NumberOfPages = NumberOfPages;
                SelectedBook.YearOfPublication = YearOfPublication;
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
 