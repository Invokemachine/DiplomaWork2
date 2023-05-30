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

namespace ChessBoard.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdvancedTheoryWindow.xaml
    /// </summary>
    public partial class AdvancedTheoryWindow : Window
    {
        public AdvancedTheoryWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            TranslateMethod();
        }

        public void TranslateMethod()
        {
            if (MainViewModel.CurrentLanguage == "English")
            {
                TitleLabel.Content = "How to face bad openings";
                TitleLabel.FontSize = 22;
                TextBlock1.Text = "Bad opening skills is a sign of a player with poor knowledge of theory. First of all, you need to study tricks in the openings you play to get better with every game. It’s almost completely useless to practice many different openings one by one and changing them every game so every clever player should stick to the one at the beginning. Opening is the stage of the game where you can get an easy advantage of player that doesn’t know what they're doing and what do they want from the opening.";
                TextBlock2.Text = "Every single one of existing openings was designed to get position with convenient development, flexible attacking ideas and tested by years and thousands of players against perfect play.";
                TextBlock3.Text = "That is why in the most of openings one little mistake could be punished by getting quick positional or material advantage and for this you firstly have to know what was your opening designed for.";
                TextBlock4.Text = "If you are convinced in your opening knowledge and you see move by your opponent that you've never seen before, it most likely will be an inaccuracy or mistake.";
                TextBlock5.Text = "To punish opponent's mistakes you need to understand what was changed in position: which piece has moved in wrong direction, which piece was blocked and what it supposed to be defending.";
                TextBlock6.Text = "Apply more pressure on the weakest places on the opponent's side of the board immediately and don't forget about the main principles of chess.";
            }
            else if (MainViewModel.CurrentLanguage == "Russian")
            {
                TitleLabel.Content = "Как иметь дело с плохими дебютами";
                TitleLabel.FontSize = 18;
                TextBlock1.Text = "Плохой дебют - знак шахматиста с плохим знанием теории. В первую очередь, Вам необходимо учить все ловушки в разыгрываемых дебютах, чтобы становиться лучше с каждой игрой. Почти бесполезно практиковать множество разных дебютов, меняя их один за другим каждую игру. Каждый догадливый шахматист должен придерживаться для начала только одного дебюта. Дебют - это стадия игры, где вы можете получить лёгкое преимущество против игрока, который не знает, что делает и что хочет получить от дебюта.";
                TextBlock2.Text = "Каждый из существующих дебютов был придуман для того, чтобы получить позицию с комфортным развитием фигур, гибкими идеями для атак и протестированы годами и тысячами игроков против идеальной игры.";
                TextBlock3.Text = "Это то, почему в большинстве дебютов малейшая ошибка может наказываться быстрым позициональным или материальным преимуществом, потому необходимо знать, для какого типа позиций дебют был придуман.";
                TextBlock4.Text = "Если Вы уверены в своём знании дебютов и видите ход, который не встречали ранее, наиболее вероятно - это неточность или ошибка.";
                TextBlock5.Text = "Чтобы наказать ошибки соперника, вам необходимо понимать, что изменилось в позиции: какие фигуры передвинулись в неправильном направлении, какие фигуры были заблокированы и что они изначально должны были защищать.";
                TextBlock6.Text = "Оказывайте больше давления на слабейшие места в стороне противника моментально и не забывайте о главных принципах шахмат.";
            }
            else if (MainViewModel.CurrentLanguage == "Korean")
            {
                TitleLabel.Content = "나쁜 오프닝에 대처하는 방법";
                TitleLabel.FontSize = 22;
                TextBlock1.Text = "잘못된 오프닝 기술은 이론에 대한 지식이 부족한 플레이어의 신호입니다. 우선, 모든 게임에서 더 나아지기 위해 플레이하는 오프닝에서 트릭을 연구해야 합니다. 많은 다른 오프닝을 하나씩 연습하고 게임마다 변경하여 모든 영리한 플레이어가 처음에 하나를 고수해야 하는 것은 거의 완전히 쓸모가 없습니다. 이론을 모르면 오프닝에서 쉽게 길을 잃을 수 있습니다.";
                TextBlock2.Text = "기존의 모든 개구부는 편리한 개발, 유연한 공격 아이디어로 위치를 차지하도록 설계되었으며 완벽한 플레이에 대해 수년 동안 수천 명의 플레이어가 테스트했습니다.";
                TextBlock3.Text = "그렇게 때문에 대부분의 오프닝에서 하나의 작은 실수가 빠른 위치 또는 물질적 이점을 얻음으로써 벌을 받을 수 있으며 이를 위해 먼저 오프닝이 무엇을 위해 설계되었는지 알아야 합니다.";
                TextBlock4.Text = "시작 지식에 확신이 있고 이전에 본 적이 없는 상대의 움직임을 본다면 그것은 부정확하거나 실수일 가능성이 높습니다.";
                TextBlock5.Text = "상대방의 실수를 처벌하려면 위치가 변경된 부분을 이해해야 합니다. 즉, 어떤 부분이 잘못된 방향으로 이동했는지, 어떤 부분이 막혔는지, 무엇을 방어해야 하는지를 이해해야 합니다.";
                TextBlock6.Text = "보드의 상대방 쪽에서 즉시 가장 약한 부분에 더 많은 압력을 가하고 체스의 주요 원칙을 잊지 마십시오.";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow rules = new RulesWindow();
            rules.Show();
            Close();
        }
    }
}
