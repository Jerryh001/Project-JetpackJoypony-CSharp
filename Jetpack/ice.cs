using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Jetpack
{
    class ice
    {
        public Label hitbox=new Label();
        private player check;
        private Graphics g;
        public int x=10;
        int y;
        int i;
        Image[] iceimage = { Properties.Resources.lolipop, Properties.Resources.lolipop2 };
        Rectangle[] obj = { new Rectangle(0, 0, 300, 86), new Rectangle(0, 0, 86, 300) };
        Rectangle[] loc = { new Rectangle(800, 0, 150, 43), new Rectangle(800, 0, 43, 150) };
        public ice(player user,int sety,int style, Bitmap background)
        {
            check = user;
            hitbox.Size = new Size(loc[style].Width-20, loc[style].Height-20);
            i = style;
            y = sety;
            loc[style].Y = y;
            g = Graphics.FromImage(background);
            hitbox.BackColor = System.Drawing.Color.Wheat;
        }
        public void draw_ice()
        {
            g.DrawImage(iceimage[i], loc[i], obj[i], GraphicsUnit.Pixel);
            loc[i].X -= 10;
            hitbox.Location = new Point(loc[i].Left + 10, loc[i].Top + 10);
            if (hitbox.Bounds.IntersectsWith(check.user.Bounds))
            {
                check.dead = 1;
            }
            x = loc[i].X;
        }
    }
}
