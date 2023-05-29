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
            SetupBoard();
            TranslateMethod();
        }

        private void TranslateMethod()
        {
            if(MainViewModel.CurrentLanguage == "English")
            {
                PreviousButton.Content = "Previous";
                NextButton.Content = "Next";
                CheckButton.Content = "Check";
            }
            else if (MainViewModel.CurrentLanguage == "Russian")
            {
                PreviousButton.Content = "Прошлая";
                NextButton.Content = "Следующая";
                CheckButton.Content = "Проверить";
            }
            else if (MainViewModel.CurrentLanguage == "Korean")
            {
                PreviousButton.Content = "이전의";
                NextButton.Content = "다음";
                CheckButton.Content = "확인";
            }
        }

        private void SetupBoard()
        {
            Board board = new();
            board[0, 0] = State.BlackRook;
            board[0, 1] = State.BlackKnight;
            board[0, 2] = State.BlackBishop;
            board[0, 3] = State.BlackQueen;
            board[0, 4] = State.BlackKing;
            board[0, 5] = State.BlackBishop;
            board[0, 6] = State.BlackKnight;
            board[0, 7] = State.BlackRook;
            for (int i = 0; i < 8; i++)
            {
                board[1, i] = State.BlackPawn;
                board[6, i] = State.WhitePawn;
            }
            board[7, 0] = State.WhiteRook;
            board[7, 1] = State.WhiteKnight;
            board[7, 2] = State.WhiteBishop;
            board[7, 3] = State.WhiteQueen;
            board[7, 4] = State.WhiteKing;
            board[7, 5] = State.WhiteBishop;
            board[7, 6] = State.WhiteKnight;
            board[3, 3] = State.WhiteRook;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
