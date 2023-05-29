using DiplomaApp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для AboutCreator.xaml
    /// </summary>
    public partial class AboutCreator : Window
    {
        public AboutCreator()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            TranslateMethod();
        }

        private void TranslateMethod()
        {
            if (MainViewModel.CurrentLanguage == "English")
            {
                TitleLabel.Content = "Creators";
                TextBlock1.Text = "Application was made by student of Kazan National Research Technical University (KNRTU) as graduate work, Nuryev Adele, group 4432";
                TextBlock2.Text = "If you have any questions, you may use our contact list down below to ask at any time:";
                Label1.Content = "Instagram: hold on, this one ain't working";
                Label2.Content = "VK: vk.com/adelechoiii";
                Label3.Content = "Email: icestorm17@mail.ru";
                Label4.Content = "Email2: dotacourierentertainment@mail.ru";
                Label5.Content = "KakaoTalk: Immortaaal";
            }
            else if (MainViewModel.CurrentLanguage == "Russian")
            {
                TitleLabel.Content = "Создатели";
                TextBlock1.Text = "Приложение было разработано студентом Казанского Национального Исследовательского Технического Университета (КНИТУ) как дипломная работа. Нурыев Адель, группа 4432";
                TextBlock2.Text = "Если возникли любые вопросы, вы можете связаться со мной по контактам ниже в любое время:";
                Label1.Content = "Инстаграм: погодите-ка, это не работает";
                Label2.Content = "ВК: vk.com/adelechoiii";
                Label3.Content = "Email: icestorm17@mail.ru";
                Label4.Content = "Email2: dotacourierentertainment@mail.ru";
                Label5.Content = "KakaoTalk: Immortaaal";
            }
            else if (MainViewModel.CurrentLanguage == "Korean")
            {
                TitleLabel.Content = "창조자";
                TextBlock1.Text = "응용 애플리케이션은 Kazan National Research Technical University (KNRTU)의 대학생 누르에브 아델, 그룹 4432에 의해 이루어졌습니다.";
                TextBlock2.Text = "질문이 있으시면 아래 연락처 목록을 사용하여 언제든지 우리에게 질문하실 수 있습니다:";
                Label1.Content = "잠깐만, 이건 작동하지 않아";
                Label2.Content = "VK: vk.com/adelechoiii";
                Label3.Content = "메일: icestorm17@mail.ru";
                Label4.Content = "메일2: dotacourierentertainment@mail.ru";
                Label5.Content = "카카오톡: Immortaaal";
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
