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
    /// Логика взаимодействия для BeginnerTheoryWindow.xaml
    /// </summary>
    public partial class BeginnerTheoryWindow : Window
    {
        public BeginnerTheoryWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            TranslateMethod();
        }

        public void TranslateMethod()
        {
            if (MainViewModel.CurrentLanguage == "English")
            {
                TitleLabel.Content = "Arrangement of chess pieces";
                PawnTextBlock.Text = "= 1 pawn";
                KnightTextBlock.Text = "= 3 pawns";
                BishopTextBlock.Text = "= 3 pawns";
                RookTextBlock.Text = "= 5 pawns";
                QueenTextBlock.Text = "= 9 pawns";
                KingTextBlock.Text = "The king is priceless. If you lost the king, the game is over";
                TextBlock1.Text = "For arrangement of pieces position on the board actually matters. Sometimes piece can cost much more only because it gives positional advantage.";
                TextBlock2.Text = "As example this position shows on evaluation bar that white is positionally almost up a pawn according to Stockfish because the bishop already stays on big opened diagonal and it gives advantage to white. It covers more squares than any other bishop on the board so we can say that it costs more than just 3 pawns.";
                TextBlock3.Text = "Or in this position computer gives big advantage to white even though they’re down 6 points of material but the pawns on b6 and c6 are too strong and nobody can’t stop them from queening and it doesn’t matter what black are about to do, white is still going to win.";
                Title = "Theory";
            }
            else if (MainViewModel.CurrentLanguage == "Russian")
            {
                TitleLabel.Content = "Расценка стоимости фигур";
                PawnTextBlock.Text = "= 1 пешка";
                KnightTextBlock.Text = "= 3 пешки";
                BishopTextBlock.Text = "= 3 пешки";
                RookTextBlock.Text = "= 5 пешек";
                QueenTextBlock.Text = "= 9 пешек";
                KingTextBlock.Text = "Король бесценен. Если вы потеряете его - игра окончена";
                TextBlock1.Text = "Для расценки стоимости фигур, их расположение на доске очень важно. Иногда фигура может расцениваться выше при оценки позиции только из-за своего расположения.";
                TextBlock2.Text = "Как пример в этой позиции шкала оценки показывает, что белые позиционально выигрывают на 1 пешку, согласно Stockfish'у, поскольку слон уже стоит на большой, открытой диагонали и это на руку белым. Этот слон закрывает больше полей, чем любой другой слон на доске, поэтому можно сказать, что он стоит больше, чем просто 3 пешки";
                TextBlock3.Text = "Или в этой позиции компьютер даёт большое преимущество белым не смотря на то, что по материалу у белых на 6 пешек меньше. Дело в том, что пешки на B6 и C6 слишком сильные и ничто не сможет остановить их от продвижения до ферзя. Неважно, что чёрные будут делать, белые всё равно выиграют.";
                Title = "Теория";
            }
            else if (MainViewModel.CurrentLanguage == "Korean")
            {
                TitleLabel.Content = "옴직임";
                PawnTextBlock.Text = "= 1 폰 개";
                KnightTextBlock.Text = "= 3 폰 개";
                BishopTextBlock.Text = "= 3 폰 개";
                RookTextBlock.Text = "= 5 폰 개";
                QueenTextBlock.Text = "= 9 폰 개";
                KingTextBlock.Text = "킹은 귀중합니다. 킹을 잃으면 게임이 종료됩니다.";
                TextBlock1.Text = "보드의 조각 위치는 실제로 중요합니다. 때때로 조각은 위치상의 이점을 제공하기 때문에 훨씬 더 비쌀 수 있습니다.";
                TextBlock2.Text = "예를 들어 이 위치는 비숍이 이미 크게 열린 대각선에 머무르고 흰색에게 이점을 주기 때문에 Stockfish에 따르면 흰색이 위치적으로 거의 폰 위에 있음을 평가 막대에 표시합니다. 그것은 보드의 다른 비숍보다 더 많은 사각형을 다루므로 비용이 3 폰보다 더 많이 든다고 말할 수 있습니다.";
                TextBlock3.Text = "또는 이 위치에서 컴퓨터는 6점의 재료를 잃었지만 b6과 c6의 폰이 너무 강하고 아무도 그들을 퀸하는 것을 막을 수 없으며 어떤 흑이 하려는지는 중요하지 않지만 백에게 큰 이점을 제공합니다. 그래도 흰색이 이길 것입니다.";
                Title = "학설";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow rulesWindow = new RulesWindow();
            rulesWindow.Show();
            Close();
        }
    }
}
