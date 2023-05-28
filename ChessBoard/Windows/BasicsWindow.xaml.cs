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
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow rules = new RulesWindow();
            rules.Show();
            Close();
        }
    }
}
