using System;
using System.Drawing;
using System.Windows.Forms;

namespace Jetpack
{
    public partial class Form1 : Form
    {
        player twilight;
        Label score = new Label();
        Bitmap mapbitmap = new Bitmap(784, 652, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        Graphics g;
        Rectangle[] back = { new Rectangle(0, 0, 784, 562), new Rectangle(0, 0, 784, 562) };
        Random red = new Random(Guid.NewGuid().GetHashCode());
        ice[] c = new ice[20];
        int ices = 0;
        int time = 100;
        int icetime = 0;
        int icescore = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            twilight = new player(mapbitmap);
            g = Graphics.FromImage(mapbitmap);
            score.Text = "冰棒：0";
            score.Location = new Point(10, 10);
            score.Font = new Font("新細明體", 20);
            score.BringToFront();
            score.Size = new Size(784 - 350, 562);
            score.BackColor = Color.Transparent;
            map.Controls.Add(score);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                twilight.pressfly();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                twilight.stopfly();
            }
        }

        private void animatetimer_Tick(object sender, EventArgs e)
        {
            icetime++;
            if (icetime > 20 && ices < 20)
            {
                icetime = 0;
                if (red.Next(0, 2) > 0)
                {
                    c[ices] = new ice(twilight, red.Next(50, 350), 1, mapbitmap);
                }
                else
                {
                    c[ices] = new ice(twilight, red.Next(20, 500), 0, mapbitmap);
                }
                ices++;
            }
            draw_back();
            twilight.draw_player();
            for (int i = 0; i < ices; i++)
            {
                if (c[i].x < -200)
                {
                    icescore++;
                    score.Text = "冰棒：" + Convert.ToString(icescore);
                    c[i] = c[ices - 1];
                    ices--;
                }
                c[i].draw_ice();
            }
            map.Image = mapbitmap;
            if (twilight.dead == 1)
            {
                score.BackColor = Color.Blue;
                score.ForeColor = Color.White;
                score.Text = "\n\n　GAME OVER\n　　總分：" + Convert.ToString(icescore) + "\n\n按這裡再玩一次";
                score.Font = new Font(score.Font.Name, 40);
                score.Location = new Point(350, 0);
                score.MouseClick += score_MouseClick;
                animatetimer.Stop();
            }
        }

        void score_MouseClick(object sender, MouseEventArgs e)
        {
            ices = 0;
            time = 100;
            icetime = 0;
            icescore = 0;
            score.BackColor = Color.Transparent;
            score.ForeColor = Color.Black;
            score.Text = "冰棒：0";
            score.Font = new Font(score.Font.Name, 20);
            score.Location = new Point(10, 10);
            c = new ice[20];
            twilight = new player(mapbitmap);
            animatetimer.Start();
            score.MouseClick -= score_MouseClick;
        }
        private void draw_back()
        {
            g.DrawImage(Properties.Resources.backgroundpng, back[0], back[1], GraphicsUnit.Pixel);
            time += 10;
            time %= 2739;
            back[1].X = time;
        }
    }
}
