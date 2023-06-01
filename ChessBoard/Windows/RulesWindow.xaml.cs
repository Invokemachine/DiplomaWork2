using ChessBoard.Windows;
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
    /// Логика взаимодействия для RulesWindow.xaml
    /// </summary>
    public partial class RulesWindow : Window
    {
        public RulesWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            TranslateMethod();
        }

        public void TranslateMethod()
        {
            if (MainViewModel.CurrentLanguage == "English")
            {
                TitleLabel.Content = "Choose the level for yourself";
                HowToPlayButton.Content = "How to play";
                BeginnerTheoryButton.Content = "Beginner";
                IntermediateTheoryButton.Content = "Intermediate";
                AdvancedTheoryButton.Content = "Advanced";
                Title = "Theory";
            }
            else if (MainViewModel.CurrentLanguage == "Russian")
            {
                TitleLabel.Content = "Выберите свой уровень";
                HowToPlayButton.Content = "Как играть";
                BeginnerTheoryButton.Content = "Начинающий";
                IntermediateTheoryButton.Content = "Средний";
                AdvancedTheoryButton.Content = "Продвинутый";
                Title = "Теория";
            }
            else if (MainViewModel.CurrentLanguage == "Korean")
            {
                TitleLabel.Content = "레벨을 직접 선택하세요";
                HowToPlayButton.Content = "게임 방법";
                BeginnerTheoryButton.Content = "초심자";
                IntermediateTheoryButton.Content = "중간물";
                AdvancedTheoryButton.Content = "진본한";
                Title = "학설";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }

        private void HowToPlayButton_Click(object sender, RoutedEventArgs e)
        {
            BasicsWindow basics = new BasicsWindow();
            basics.Show();
            Close();
        }

        private void BeginnerTheoryButton_Click(object sender, RoutedEventArgs e)
        {
            BeginnerTheoryWindow beginnerTheoryWindow = new BeginnerTheoryWindow();
            beginnerTheoryWindow.Show();
            Close();
        }

        private void IntermediateTheoryButton_Click(object sender, RoutedEventArgs e)
        {
            IntermediateTheoryWindow intermediateTheoryWindow = new IntermediateTheoryWindow();
            intermediateTheoryWindow.Show();
            Close();
        }

        private void AdvancedTheoryButton_Click(object sender, RoutedEventArgs e)
        {
            AdvancedTheoryWindow advanced = new AdvancedTheoryWindow();
            advanced.Show();
            Close();
        }
    }
}
