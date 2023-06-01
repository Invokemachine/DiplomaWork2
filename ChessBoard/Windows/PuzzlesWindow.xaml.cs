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
        public static int newpuzzle;
        public PuzzlesWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            TranslateMethod();
            PuzzlesComboBox.ItemsSource = new List<string>()
            {
                "1","2","3", "4", "5", "6"
            };
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

        private void PuzzlesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainViewModel mainViewModel = new MainViewModel();
            switch (PuzzlesComboBox.SelectedIndex)
            {
                case 0:
                    {
                        newpuzzle = 1;
                        mainViewModel.CurrentPuzzleName = "PuzzleBeginner1";
                        break;
                    }
                case 1:
                    {
                        newpuzzle = 2;
                        mainViewModel.CurrentPuzzleName = "PuzzleBeginner2";
                        break;
                    }
                case 2:
                    {
                        newpuzzle = 3;
                        mainViewModel.CurrentPuzzleName = "PuzzleBeginner3";
                        break;
                    }
                case 3:
                    {
                        newpuzzle = 4;
                        mainViewModel.CurrentPuzzleName = "PuzzleBeginner4";
                        break;
                    }
                case 4:
                    {
                        newpuzzle = 5;
                        mainViewModel.CurrentPuzzleName = "PuzzleBeginner5";
                        break;
                    }
                case 5:
                    {
                        newpuzzle = 6;
                        mainViewModel.CurrentPuzzleName = "PuzzleBeginner6";
                        break;
                    }
            }
        }
    }
}
