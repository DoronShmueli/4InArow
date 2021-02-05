using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _4InARowMiniProject
{
    class player
    {
        private Image token;
        
        public player(bool turn,int x, int y,Grid Gridi)   // מקבל תור ומכין מסך מעודכן
        {
            token = new Image();
            if (turn)    // מציב מטבע צהוב על מפה במיקום נבחר
            {
                token.Source = new BitmapImage(new Uri(@"image\YellowToken.png", UriKind.RelativeOrAbsolute));
                token.Width = 300;
                token.Height = 170;
            }
            else        // מציב מטבע אדום על מפה במיקום נבחר
            {
                token.Source = new BitmapImage(new Uri(@"image\RedToken.png", UriKind.RelativeOrAbsolute));
                token.Width = 300;
                token.Height = 170;
            }
            Gridi.Children.Add(token);
            Grid.SetColumn(token, x);
            Grid.SetRow(token, y);
        }
    }
    enum Tokentype   // סוג תור אדום צהוב או רקע
    {
        Red=1,
        Yellow=2,
        backround=0,
    }
}
