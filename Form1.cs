using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot_BlackWhite
{
    public partial class Form1 : Form
    {
        public double wx = 0, wy = 0;
        public double speed = 2f, zoom = 2d, zoomSpeed = 0.001d;
        public int res = 5;
        public Thread thread;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            zoom -= zoomSpeed / (3 - zoom);
            Draw();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Draw();
           
        }
        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("Space - Stop\nQ - Add Resolution\nE - Low Resolution\n+ - Add Zoom Speed\n- - Low Zoom Speed\nArrows - Move");
            }
            if (e.KeyCode == Keys.Space)
            {
                timer1.Stop();
            }
            if (e.KeyCode == Keys.Q)
            {
                res -= 1;
            }
            if (e.KeyCode == Keys.E)
            {
                res += 1;
            }
            if (e.KeyCode == Keys.Add)
            {
                zoom -= zoomSpeed/zoom;
                Draw();
            }
            if (e.KeyCode == Keys.Subtract)
            {
                zoom += zoomSpeed/zoom;
                Draw();
            }
            if (e.KeyCode == Keys.Up)
            {
                wy -= speed *  (5 - Math.Abs(zoom));
                Draw();
            }
            if (e.KeyCode == Keys.Down)
            {
                wy += speed * (5 - Math.Abs(zoom));
                Draw();
            }
            if (e.KeyCode == Keys.Left)
            {
                wx -= speed * (5 - Math.Abs(zoom));
                Draw();
            }
            if (e.KeyCode == Keys.Right)
            {
                wx += speed * (5 - Math.Abs(zoom));
                Draw();
            }
            if (e.KeyCode == Keys.Return)
            {

                Draw();
            }
        }

        public void Draw()
        {
            label1.Text = "Zoom: " + zoom;
            if (res <= 0)
            {
                res = 1;
            }
            Bitmap frame = new Bitmap(Width / res, Height / res);
            for (int x = 0; x < Width/res; x++)
            {
                for (int y = 0; y < Height/res; y++)
                {
                    double a = (double)((x + (wx/res/zoom)) - ((Width / 2d) / res)) / (double)(Width / zoom / res / 1.77777778f);
                    double b = (double)((y + (wy/res/zoom)) -( (Height / 2d) / res)) / (double)(Height / zoom/res);
                    Numbers c = new Numbers(a, b);
                    Numbers z = new Numbers(0, 0);
                    int it = 0;

                    do
                    {
                        it++;
                        z.Square();
                        z.Add(c);
                        if (z.Magnitude() > 2.0d)
                        {
                            break;
                        }
                    } while (it < 100);
                    frame.SetPixel(x, y, Color.FromArgb((byte)(it*2.55f), (byte)(it * 2.55f), (byte)(it * 2.55f)));
                }
            }

            pictureBox1.Image = frame;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
