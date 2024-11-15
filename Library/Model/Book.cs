using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library.Model
{
    internal class Book : INotifyPropertyChanged
    {
        //Книга в списке должна иметь: Название, автора, год выпуска, жанр, кол-во страниц
        private string _title;
        private string _author;
        private int _yearOfPublication;
        private string _genre;
        private int _numberOfPages;

        public string Title
        {
            get { return _title; }

            set 
            { 
                _title = value;
                if (_title == null) 
                {
                    MessageBox.Show("Книга должна иметь название!");
                }
                OnPropertyChanged("Title");
            } 
        }
        public string Author 
        { 
            get { return _author; } 

            set
            {
                _author = value;
                if (_author == null)
                {
                    MessageBox.Show("У книги должен быть автор!");
                }
                OnPropertyChanged("Author");
            } 
        }
        public int YearOfPublication
        {
            get { return _yearOfPublication;}

            set
            {
                _yearOfPublication = value;
                if (_yearOfPublication < 0)
                {
                    MessageBox.Show("Книга не может иметь такого года издания!");
                }
                OnPropertyChanged("YearOfPublication");
            }
        }
        public string Genre
        {
            get { return _genre; }

            set
            {
                _genre = value;
                if (_genre == null)
                {
                    MessageBox.Show("У книги должен быть жанр!");
                }
                OnPropertyChanged("Genre");
            }
        }
        public int NumberOfPages
        {
            get { return _numberOfPages; }
            
            set
            {
                _numberOfPages = value;
                if (_numberOfPages < 0)
                {
                    MessageBox.Show("У книги не может быть отрицательно количество страниц!");
                }
                OnPropertyChanged("NumberOfPages");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
