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
    /// Логика взаимодействия для IntermediateTheoryWindow.xaml
    /// </summary>
    public partial class IntermediateTheoryWindow : Window
    {
        public IntermediateTheoryWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            TranslateMethod();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow rules = new RulesWindow();
            rules.Show();
            Close();
        }

        public void TranslateMethod()
        {
            if (MainViewModel.CurrentLanguage == "English")
            {
                TitleLabel.Content = "How to avoid stalemates";
                TextBlock1.Text = "As you all know stalemate is a situation where the enemy’s king has no moves on their turn (in case when there's no more pieces on the board remaining or they're all blocked and have no moves as well). If the same happens while it’s not your opponent’s move you still can make a move to free up some space near the king or let your opponent have some other move. So how to always avoid these situations? These hints will help you to memorize the ways and upgrade your board vision.";
                TextBlock2.Text = "First of all, pay attention on the square where the enemy's king placed at the moment: if it's placed in some empty place on the board - try to cut him off the escape squares and let the king have 2 free squares for shuffling from one to other.";
                TextBlock3.Text = "The second is don't forget about other pieces on the board: if the enemy's king has no escape, you won't make a stalemate until all of the other pieces are gone or unable to move.";
                TextBlock4.Text = "The third is try to give a checks if it's possible. Sometimes you can checkmate your opponent by accident so it's better if every attacking move would be a check.";
                TextBlock5.Text = "Sacrifice material if necessary. WInning a lot of material doesn't always mean winning the game. On the chess board might occur positions which will lead to stalemate after picking up the next opponent's piece. Try not to be greedy, follow the previous rules better: throw a checks, outzone the king and guard your own king.";
            }
            else if (MainViewModel.CurrentLanguage == "Russian")
            {
                TitleLabel.Content = "Как избегать пата";
                TextBlock1.Text = "Как вы знаете, пат - это ситуация, где вражеский король не имеет доступных ходов на их ход (с учётом того, что на доске больше нет вражеских фигур или они заблокированы и не имеют доступных ходов). Если то же происходит во время Вашего хода, вы можете освободить поле рядом с вражеским королём или сделать возможным какой-то другой ход для противника. Так как же всегда избегать этих ситуаций? Эти подсказки помогут Вам запомнить нужные способы и прокачать видение доски.";
                TextBlock2.Text = "Во-первых, обращайте внимание на то, где расположен вражеский король в данный момент: если он расположен в пустом пространстве на доске - попытайтесь отрезать его от максимального количества свободных полей, оставив 2 для того, чтобы у противника была возможность ходить из стороны в сторону.";
                TextBlock3.Text = "Во-вторых, не забывайте о других фигурах на доске: если у короля противника нет выхода, на доске не возникнет пат до тех пор, пока все другие фигуры противника не станут неспособны двигаться или не исчезнут с доски.";
                TextBlock4.Text = "В-третьих - давайте противнику шах, если это возможно. Иногда можно матовать противника случайно, так что лучше, если каждый атакующий ход будет шахом.";
                TextBlock5.Text = "Жертвуйте материал, если это необходимо. Выигрыш по материалу не всегда означает победу в игре. На шахматной доске могут возникнуть позиции, в которых может случиться пат, если кто-то из противников забирает последнюю фигуру оппонента. Старайтесь не быть жадными, лучше следуйте предыдущим правилам: давайте шахи, отрежьте отход королю и держите в безопасности своего короля.";
            }
            else if (MainViewModel.CurrentLanguage == "Korean")
            {
                TitleLabel.Content = "스테일메이트를 피하는 방법";
                TextBlock1.Text = "모두 아시다시피 스테일메이트는 적의 왕이 자신의 차례에 움직일 수 없는 상황입니다(보드에 남은 조각이 더 이상 없거나 모두 막혀 움직일 수 없는 경우). 상대방의 이동이 아닌데도 같은 일이 발생하면 여전히 이동하여 왕 근처의 공간을 확보하거나 상대방이 다른 이동을 하도록 할 수 있습니다. 그렇다면 이러한 상황을 항상 피하는 방법은 무엇입니까? 이 힌트는 방법을 기억하고 보드 비전을 업그레이드하는 데 도움이 될 것입니다.";
                TextBlock2.Text = "우선, 적의 왕이 현재 배치한 사각형에 주의를 기울이십시오. 보드의 빈 공간에 배치된 경우 - 그를 탈출 사각형에서 차단하고 왕이 셔플할 수 있는 2개의 무료 사각형을 하십시오.";
                TextBlock3.Text = "두 번째는 보드의 다른 조각을 잊지 마십시오. 적의 왕이 탈출할 수 없다면 다른 모든 조각이 사라지거나 움직일 수 없을 때까지 교착 상태에 빠지지 않을 것입니다.";
                TextBlock4.Text = "세 번째는 가능하면 수표를 주려고 노력하는 것입니다. 때때로 상대를 우연히 체크메이트할 수 있으므로 모든 공격 동작이 체크가 되는 것이 좋습니다.";
                TextBlock5.Text = "필요한 경우 재료를 희생하십시오. 많은 자료를 얻는다고 해서 항상 게임에서 이기는 것은 아닙니다. 체스판에서 다음 상대방의 말을 집은 후 교착상태에 빠지는 위치가 발생할 수 있습니다. 욕심 부리지 말고 이전 규칙을 더 잘 따르십시오. 수표를 던지고 왕을 능가하고 자신의 왕을 지키십시오.";
            }
        }
    }
}
