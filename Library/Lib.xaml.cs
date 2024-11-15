using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Library.View;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library.ViewModel;

namespace Library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Lib : Window
    {
        public Lib()
        {
            /* View: 
            Экран 1: Список книг (через LV, возможно, в будущем поменяю) ------> поменял на ЛистБокс с использованием СтакПанела
            Книга в списке должна иметь: Название, автора, год выпуска, жанр, кол-во страниц 
            Книги реализовать через класс.
            На главном экране должны быть кнопки: добавить, редактировать, удалить книгу ------> сделано

            Экран 2: Добавление/редактирование книг
            Экран открывается при добавлении новой книги/редактирования существующей
            Данные те же, что и сверху!
            Должны иметься кнопки: сохранить, отменить.

            Экран 3: Детали книги
            Используется для отображения подробной информации о книгах, открывается при нажатии на выбранную книгу
            в списке. -------> сделано
            ДОБАВИТЬ ФИЛЬТРАЦИЮ ПО: ЖАНРУ, АВТОРУ, ГОДУ ВЫПУСКА (дефолт - год выпуск) ----> впадлу

            Model:
            Класс Book, который хранит данные о книге ------> сделано

            View-model:
            Классы, управляющие логикой приложения. ------> сделано
            */


            InitializeComponent();
            var viewModel = new MainViewModel();
            viewModel.NavigateToMainBookPage = () =>
            {
                var mainFrame = new MainFrame();
                {
                    DataContext = viewModel;
                };
                MyFrame.Navigate(mainFrame);
            };

            viewModel.NavigateToAddBookPage = () =>
            {
                var addPage = new AddUpdFrame();
                {
                    DataContext = viewModel; // Передаем ViewModel в AddPage
                };
                MyFrame.Navigate(addPage);
            };
            DataContext = viewModel;
        }
    }
}
