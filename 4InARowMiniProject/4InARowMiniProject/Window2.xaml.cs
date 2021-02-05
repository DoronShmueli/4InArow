using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _4InARowMiniProject
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        Image[] btn=new Image[7]; // מערך שיוצר לוח משחק
        bool turn = false;    // תור שחקן
         int[,] Map = {

        {9, 0, 0, 0, 0, 0, 0, 0, 9 },
        {9, 0, 0, 0, 0, 0, 0, 0, 9 },
        {9, 0, 0, 0, 0, 0, 0, 0, 9 },
        {9, 0, 0, 0, 0, 0, 0, 0, 9 },
        {9, 0, 0, 0, 0, 0, 0, 0, 9 },
        {9, 0, 0, 0, 0, 0, 0, 0, 9 },
        {9, 9, 9, 9, 9, 9, 9, 9, 9 },

         };
        public Window2()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)    // מגדיר כפתורי משחק ובודק לחיצה
            {
                btn[i] = new Image();
                btn[i].MouseDown += Collum1_Click;
                btn[i].MouseEnter += Btn_MouseEnter;
                btn[i].MouseLeave += Btn_MouseLeave;
                btn[i].Stretch = Stretch.Fill;
                btn[i].Uid = i + "";
                Grid.SetColumn(btn[i], i);
                Grid.SetRow(btn[i], 0);
                Gridi.Children.Add(btn[i]);
                btn[i].Source = new BitmapImage(new Uri(@"image\BackGround.png", UriKind.Relative));
            }
        }
       private void Btn_MouseEnter(object sender, MouseEventArgs e)    // בודק אם עכבר עומד על כפתור
       {
           Image img = (Image)sender;
           int i = int.Parse(img.Uid);
           if (turn)
              btn[i].Source = new BitmapImage(new Uri(@"image\YellowToken.png", UriKind.Relative));
           else
               btn[i].Source = new BitmapImage(new Uri(@"image\RedToken.png", UriKind.Relative));
       
       }
       
       private void Btn_MouseLeave(object sender, MouseEventArgs e)   // בודק אם עכבר יצא מכפתור
       {
           Image img = (Image)sender;
           int i = int.Parse(img.Uid);
            btn[i].Source = new BitmapImage(new Uri(@"image\BackGround.png", UriKind.Relative));
        }

        private void Collum1_Click(object sender, RoutedEventArgs e)    // בודק האם התבצעה לחיצה
        {
            int x = Grid.GetColumn((Image)sender); ;
            int y = -1;
                while (Map[y+1,x]==(int) Tokentype.backround)    // שם מטבע ומחליף תור
            {
                y++;
                
            }
            new player(turn, x, y, Gridi); 
            if (turn)    //  בודק האם צהוב ניצח ואם כן מעביר למסך צהוב מנצח
            {
                Map[y, x] = (int)Tokentype.Yellow;
                if (IsWin(Tokentype.Yellow, x, y))
                {
                    YellowWin Yellow = new YellowWin();
                    Yellow.Show();
                    this.Close();
                }
            }
            else
            {
                Map[y, x] = (int)Tokentype.Red;
                if (IsWin(Tokentype.Red, x, y))  // בודק אם אדום ניצח ואם כן מעביר למסך ניצחון אדום
                {
                    RedWin Red = new RedWin();
                    Red.Show();
                    this.Close();
                }
            }

            turn = !turn;
               
        }
        private bool IsWin(Tokentype token, int x, int y)   // בדיקה שרצה על המערך הדו ממדי ובודקת האם יש מנצח לאחר כל תור
        {
            if (Map[y, x] == (int)token && Map[y, x + 1] == (int)token && Map[y, x + 2] == (int)token && Map[y, x + 3] == (int)token)
            {
                return true;
            }
            else if (Map[y, x] == (int)token && Map[y, x - 1] == (int)token && Map[y, x - 2] == (int)token && Map[y, x - 3] == (int)token)
            {
                return true;
            }
            else if (Map[y, x] == (int)token && Map[y + 1, x] == (int)token && Map[y + 2, x] == (int)token && Map[y + 3, x] == (int)token) 
            {
                return true;
            }
            else if (Map[y, x] == (int)token && Map[y - 1, x] == (int)token && Map[y - 2, x] == (int)token && Map[y - 3, x] == (int)token)
            {
                return true;
            }
            else if (Map[y, x] == (int)token && Map[y - 1, x + 1] == (int)token && Map[y - 2, x + 2] == (int)token && Map[y - 3, x + 3] == (int)token)
            {
                return true;
            }
            else if (Map[y,x] == (int)token && Map[y + 1, x + 1] == (int)token && Map[y + 2, x + 2] == (int)token && Map[y + 3, x + 3] == (int)token)
            {
                return true;
            }
            else if (Map[y, x] == (int)token && Map[y + 1, x - 1] == (int)token && Map[y + 2, x - 2] == (int)token && Map[y + 3, x - 3] == (int)token)
            {
                return true;
            }
            else if (Map[y, x] == (int)token && Map[y - 1, x - 1] == (int)token && Map[y - 2, x - 2] == (int)token && Map[y - 3, x - 3] == (int)token)
            {
                return true;
            }
        
            {
                return false;
            }
        }
    }
}
