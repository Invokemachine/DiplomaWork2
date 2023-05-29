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
    /// Логика взаимодействия для BasicsWindow.xaml
    /// </summary>
    public partial class BasicsWindow : Window
    {
        public BasicsWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            TranslateMethod();
        }

        public void TranslateMethod()
        {
            if (MainViewModel.CurrentLanguage == "English")
            {
                TitleLabel.Content = "Movement";
                TextBlock1.Text = "Learn how pieces in chess can move is one of the most important basic parts.";
                Title1.Content = "Pawns";
                TextBlock2.Text = "If the pawn never moved from the 2nd (or the 6th for black) row it can move on 1 or 2 squares in front of itself. If the pawn moved at least once it can move forward only on 1 square for 1 move. By getting to the opposite side of the board pawn can become any other piece: knight, bishop, rook or queen.";
                TextBlock3.Text = "In this case c pawn is blocked by enemy’s knight as well as b pawn is stuck behind white’s dark-square bishop. But pawns can capture enemy’s pieces diagonally on 1 square in front them. So if in this position white would have 3 moves in a row they could capture all of the black’s queens and promote.";
                Title2.Content = "Knights";
                TextBlock4.Text = "Knight is the only chess piece which can jump over any other pieces and knights move 2 squares up or down and 1 on the left or right and etc (alike letter “L” upside down).";
                Title3.Content = "Bishops";
                TextBlock5.Text = "Bishop can move on any quantity of squares diagonally but they can not change their basic color. Bishops are very useful together. In the most of cases advantage is given to the side with centralized and supporting each other pieces and better placed bishops.";
                Title4.Content = "Queen";
                TextBlock6.Text = "The queen is the most powerful of all pieces. It's worth more than any other piece and that is why it is dangerous to try to attack your opponent without other pieces, queen can't cause damage to the opponents king only by itself. Queen is able to move in any direction through any amount of squares.";
                Title5.Content = "Rooks";
                TextBlock7.Text = "Rooks can move straight up, down, left or right. Rooks are very useful on the open files.";
                Title6.Content = "Castling";
                TextBlock8.Text = "If your king and rook have never moved in game, you can use the rule of castling the king to hide him in the more safe side of the board. Castling moves the rook next to the kings home square and moves the king next to the rook on side which was chosen for casting.";
                Title7.Content = "Capturing";
                TextBlock9.Text = "Pieces can capture each other during the game, for any piece except the pawn capturing is allowed when the opponent's piece is placed at one of the possible squares for moving the chosen piece. Pawns can capture other pieces only when they are placed diagonally in front.";
            }
            else if (MainViewModel.CurrentLanguage == "Russian")
            {
                TitleLabel.Content = "Передвижение фигур";
                TextBlock1.Text = "Изучить то, как ходят фигуры - одна из важнейших базовых частей игры.";
                Title1.Content = "Пешки";
                TextBlock2.Text = "Если пешка ещё не двигалась со 2 (или 6 для чёрных фигур) линии, она может передвинуться на одно или два поля вперёд перед собой. Если пешкой уже походили, она может двигаться только на одно поле вперёд за ход. При достижении пешкой противоположного конца доски, она может превратиться в любую другую фигуру: конь, слон, ладья или ферзь.";
                TextBlock3.Text = "В этом случае пешка на C заблокирована вражеским конём, как и пешка B застряла позади чернопольного слона белых. Но пешки могут съедать вражеские фигуры диагонально на одно поле перед ними. Так что если бы у белых было три хода подряд в этой позиции, они могли бы съесть всех ферзей чёрных и превратиться.";
                Title2.Content = "Конь";
                TextBlock4.Text = "Конь - единственная фигура, способная перепрыгивать через другие. Передвигается на два поля вперёд или назад и на одно вправо или влево, либо на 2 вправо или влево и на одно вверх или вниз (Точно как буква “Г”).";
                Title3.Content = "Слон";
                TextBlock5.Text = "Слоны могут передвигаться диагонально на любое количество полей, но не могут сменить свой изначальный цвет полей, на которых расположены. Слоны очень полезны в паре. В большинстве случаев преимущество отдаётся стороне с централизованными и поддерживающими друг друга фигурами и более удачно расположенными слонами.";
                Title4.Content = "Ферзь";
                TextBlock6.Text = "Ферзь - сильнейшая шахматная фигура. Ферзь расценивается дороже любой другой фигуры, поэтому опасно выдвигать его в атаку без поддержки других фигур, ферзь не может нанести существенный урон вражескому королю самостоятельно. Ферзь может передвигаться на любое количество клеток в любом направлении.";
                Title5.Content = "Ладья";
                TextBlock7.Text = "Ладьи могут двигаться вверх, вниз, вправо и влево на любое количество клеток. Они очень полезны в открытых позициях.";
                Title6.Content = "Рокировка";
                TextBlock8.Text = "Если ваш король и ладья ни разу не двинулись за игру, вы можете использовать правило рокировки, чтобы спрятать короля в более безопасной части доски. Рокировка ставит ладью рядом с королём и переносит короля в сторону, ладья с которой была выбрана для рокировки.";
                Title7.Content = "Съедение фигур";
                TextBlock9.Text = "Фигуры могут 'съедать' друг друга в течение игры. Для всех фигур, кроме пешек, вражеская фигура становится доступной для съедения в случае, если она стоит на пути возможных ходов. Для пешек доступно съедение фигур только по диагонали на 1 поле перед ними.";
            }
            else if (MainViewModel.CurrentLanguage == "Korean")
            {
                TitleLabel.Content = "옴직임";
                TextBlock1.Text = "체스에서 말들이 어떻게 옴직임는지 배우는 것은 가장 중요한 기본 부분 중 하나입니다.";
                Title1.Content = "폰";
                TextBlock2.Text = "폰이 2번째 행(검은색의 경우 6번째 행)에서 한 번도 이동하지 않은 경우 자신의 앞에서 1~2칸 이동할 수 있습니다. 폰이 한 번 이상 움직인 경우 1칸 이동 동안 1칸만 앞으로 이동할 수 있습니다. 보드 반대편에 도달하면 폰은 나이트, 비숍, 루크 또는 퀸과 같은 다른 말이 될 수 있습니다.";
                TextBlock3.Text = "이 경우 'C' 폰은 적의 기사에 의해 막히고 'B' 폰은 흰색의 어두운 사각형 비숍 뒤에 갇 히게 됩니다. 그러나 폰은 적의 기물을 대각선으로 잡을 수 있습니다. 따라서 이 위치에서 백이 연속으로 3번 이동하면 흑의 모든 퀸을 캡처하고 승급할 수 있습니다.";
                Title2.Content = "나이트";
                TextBlock4.Text = "나이트는 다른 말을 뛰어넘을 수 있는 유일한 체스 기물이며 나이트는 위나 아래로 2칸, 왼쪽이나 오른쪽으로 1칸을 이동합니다(문자 'L' 이 거꾸로 됨).";
                Title3.Content = "비숍";
                TextBlock5.Text = "비숍은 대각선으로 얼마든지 이동할 수 있지만 기본 색상은 변경할 수 없습니다. 비숍은 함께 있으면 매우 유용합니다. 대부분의 경우 중앙 집중화되고 서로 지원하는 조각과 더 나은 위치에 있는 주교가 있는 쪽이 유리합니다.";
                Title4.Content = "퀸";
                TextBlock6.Text = "퀸은 모든 조각 중에서 가장 강력합니다. 어떤 기물보다 가치가 높기 때문에 다른 기물 없이 상대를 공격하려 하는 것은 위험하며, 퀸은 혼자서는 상대의 킹에게 피해를 줄 수 없습니다. 퀸은 모든 사각형을 통해 모든 방향으로 이동할 수 있습니다.";
                Title5.Content = "루크";
                TextBlock7.Text = "루크는 위, 아래, 왼쪽 또는 오른쪽으로 똑바로 이동할 수 있습니다. 루크는 열린 파일에서 매우 유용합니다.";
                Title6.Content = "캐슬링";
                TextBlock8.Text = "킹과 루크가 게임에서 한 번도 움직이지 않은 경우 킹을 캐슬링하는 규칙을 사용하여 보드의 더 안전한 쪽에 숨길 수 있습니다. 캐슬링은 킹의 홈 스퀘어 옆에 있는 루크를 이동시키고 캐스팅을 위해 선택된 루크 옆에 있는 킹을 이동시킵니다.";
                Title7.Content = "캡처링";
                TextBlock9.Text = "상대방의 조각이 선택한 조각을 이동하기 위해 가능한 사각형 중 하나에 배치될 때 폰 캡처가 허용되는 것을 제외한 모든 조각에 대해 조각은 게임 중에 서로를 캡처할 수 있습니다. 폰은 앞에 대각선으로 배치된 경우에만 다른 기물을 잡을 수 있습니다.";
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
