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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _4InARowMiniProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)   // לחיצה על כפתור הסטארט וגישה למסך משחק
        {
            Window2 Game = new Window2();
            Game.Show();
            this.Close();
        }

        private void BtnAboutTheCreator_Click(object sender, RoutedEventArgs e)     // לחיצה על כפתור "על היוצר" וגישה למסך
        {
            AboutME about = new AboutME();
            about.Show();
            this.Close();
        }
    }
    }

