using DiplomaApp;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace ChessBoard.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChampionsWindow.xaml
    /// </summary>
    public partial class ChampionsWindow : Window
    {
        DiplomaDataBaseContext db = new DiplomaDataBaseContext();
        List<Champion> champions = new List<Champion>();
        MainViewModel mainViewModel = new MainViewModel();
        public ChampionsWindow()
        {
            InitializeComponent();
            champions = db.Champions.ToList();
            ChampionList.ItemsSource = champions;
            PictureInit();
            DataContext = new MainViewModel();
            LanguageInit();
        }

        private void LanguageInit()
        {
            if (MainViewModel.CurrentLanguage == "English")
            {
                NameFilter.ItemsSource = new List<string>()
                {
                    "Name", "Country"
                };
                TypeFilter.ItemsSource = new List<string>
                {
                    "Classical", "Rapid", "Blitz", "Bullet"
                };
                TitleLabel.Content = "The best players in the world";
                Title = "Chess champions";
            }
            else if (MainViewModel.CurrentLanguage == "Russian")
            {
                NameFilter.ItemsSource = new List<string>()
                {
                    "Имя", "Страна"
                };
                TypeFilter.ItemsSource = new List<string>
                {
                    "Классика", "Рапид", "Блитц", "Пуля"
                };
                TitleLabel.Content = "Лучшие игроки мира";
                Title = "Лучшие шахматисты";
            }
            else if (MainViewModel.CurrentLanguage == "Korean")
            {
                NameFilter.ItemsSource = new List<string>()
                {
                    "이름", "국가"
                };
                TypeFilter.ItemsSource = new List<string>
                {
                    "클래식", "래피드", "블리츠", "불렛"
                };
                TitleLabel.Content = "세계 최고의 선수들";
                Title = "세계 최고의 선수들";
            }
        }

        private void PictureInit()
        {
            foreach (Champion champion in champions)
            {
                champion.Picture = $"/Resources/Players/{champion.Picture}";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentChampions = db.Champions.ToList();
            currentChampions = currentChampions.Where(p => p.Name.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            champions = currentChampions;
            if (!String.IsNullOrEmpty(SearchTextBox.Text))
                ChampionList.ItemsSource = currentChampions.OrderBy(p => p.Name).ToList();
            else
                ChampionList.ItemsSource = currentChampions.OrderByDescending(p => p.ClassicalChessFideElo).ToList();
        }

        private void NameFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            champions = db.Champions.ToList();
            switch (NameFilter.SelectedIndex)
            {
                case 0:
                    {
                        ChampionList.ItemsSource = champions.OrderBy(p => p.Name);
                        break;
                    }
                case 1:
                    {
                        ChampionList.ItemsSource = champions.OrderBy(p => p.Country);
                        break;
                    }
            }
        }

        private void TypeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            champions = db.Champions.ToList();
            switch (TypeFilter.SelectedIndex)
            {
                case 0:
                    {
                        ChampionList.ItemsSource = champions.OrderByDescending(p => p.ClassicalChessFideElo);
                        break;
                    }
                case 1:
                    {
                        ChampionList.ItemsSource = champions.OrderByDescending(p => p.RapidChessFideElo);
                        break;
                    }
                case 2:
                    {
                        ChampionList.ItemsSource = champions.OrderByDescending(p => p.BlitzChessFideElo);
                        break;
                    }
                case 3:
                    {
                        ChampionList.ItemsSource = champions.OrderByDescending(p => p.BulletChessFideElo);
                        break;
                    }
            }
        }
    }
}
