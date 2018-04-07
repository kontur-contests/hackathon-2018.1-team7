using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevUiWinForms
{
    public partial class MainForm : Form
    {
        private static readonly Pen Pen = new Pen(Color.Black,1);

        public class Actor
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        private static readonly Image image = new Bitmap(512, 512);

        private readonly Actor[] _actors = new Actor[500];

        public MainForm()
        {
            InitializeComponent();
        }

        private void Render()
        {
            while (true)
            {
                pictureBox1.Invoke(new Action(() =>
                {
                    using (var z = Graphics.FromImage(image))
                    {
                        z.Clear(Color.White);
                        
                        DrawGrid(z, 20, 20, 512, 512);
                    }
                    
                    pictureBox1.BackgroundImage = image;
                    
                    pictureBox1.Invalidate();
                }));

                Task.Delay(10).Wait();
            }
        }

        private void DrawGrid(Graphics gfx, int stepX, int stepY, int sizeX, int sizeY)
        {
            for (int i = 0; i < sizeX; i += stepX)
            {
                gfx.DrawLine(Pen, new Point(i, 0), new Point(i, sizeY));
            }

            for (int i = 0; i < sizeY; i += stepY)
            {
                gfx.DrawLine(Pen, new Point(0, i), new Point(sizeX, i));
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            var rnd = new Random(DateTime.Now.GetHashCode());
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i] = new Actor { X = 50 + rnd.Next(400), Y = 50 + rnd.Next(400) };
            }

            Task.Factory.StartNew(Render);
        }
    }
}
