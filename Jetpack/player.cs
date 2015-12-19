using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jetpack
{
    class player
    {
        public Label user = new Label();
        private Graphics g;
        int speed = 0;
        int up = -1;
        static int count = 1;
        int isfly = 0;
        int x = 100;
        int y = 450;
        public int dead=0;
        private Rectangle[] objsize = { new Rectangle(100, 445, 110, 100), new Rectangle(0, 0, 110, 100), new Rectangle(100, 450, 106, 102), new Rectangle(0, 0, 106, 102) };
        public player(Bitmap background)
        {
            g = Graphics.FromImage(background);
            user.Size = new Size(50, 50);
            Timer flytimer = new Timer();
            flytimer.Start();
            flytimer.Interval = 70;
            flytimer.Tick += flytimer_Tick;
        }
        public void draw_player()
        {
            if (y >= 450)
            {
                g.DrawImage(Properties.Resources.walk, objsize[0], objsize[1], GraphicsUnit.Pixel);
                objsize[1].Y = 100 * count;
            }
            else
            {
                g.DrawImage(Properties.Resources.fly, objsize[2], objsize[3], GraphicsUnit.Pixel);
                objsize[2].X = x;
                objsize[2].Y = y;
                objsize[3].Y = 102 * count;
            }
            user.Location = new Point(x + 40, y + 30);
            count++;
            count %= 16;
        }
        void flytimer_Tick(object sender, EventArgs e)
        {
            if (isfly == 1)
            {
                speed += up;
            }
            else
            {
                speed -= up;
            }
            if (speed <= 0)
            {
                up = -up;
                speed = -speed;
            }
            if (speed > 4)
            {
                speed = 5;
            }
            for (int i = 0; i < speed; i++)
            {
                y -= up * speed;
                if (y >= 450)
                {
                    y = 450;
                    speed = 0;
                    up = 1;
                    break;
                }
                else if (y <= 0)
                {
                    y = 0;
                    speed = 0;
                    up = -1;
                    break;
                }
            }
        }
        public void pressfly()
        {
            isfly = 1;
        }
        public void stopfly()
        {
            isfly = 0;
        }
    }

}
