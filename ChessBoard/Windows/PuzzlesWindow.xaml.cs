using DiplomaApp;
using System;
using System.Collections.Generic;
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

namespace ChessBoard
{
    /// <summary>
    /// Логика взаимодействия для PuzzlesWindow.xaml
    /// </summary>
    public partial class PuzzlesWindow : Window
    {
        public PuzzlesWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            TranslateMethod();

        }

        private void TranslateMethod()
        {
            if (MainViewModel.CurrentLanguage == "English")
            {
                PreviousButton.Content = "Previous";
                NextButton.Content = "Next";
                CheckButton.Content = "Check";
                CheckButton.FontSize = 16;
            }
            else if (MainViewModel.CurrentLanguage == "Russian")
            {
                PreviousButton.Content = "Прошлая";
                NextButton.Content = "След.";
                CheckButton.Content = "Проверить";
                CheckButton.FontSize = 12;
            }
            else if (MainViewModel.CurrentLanguage == "Korean")
            {
                PreviousButton.Content = "이전의";
                NextButton.Content = "다음";
                CheckButton.Content = "확인";
                CheckButton.FontSize = 16;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
