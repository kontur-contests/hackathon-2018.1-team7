using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;

namespace DevUiWinForms
{
    
    public partial class MainForm : Form
    {
        private static readonly Pen Pen = new Pen(Brushes.AliceBlue);
        private static readonly Pen TeamAPen = new Pen(Brushes.Red);
        private static readonly Pen TeamBPen = new Pen(Brushes.Blue);
        private static IWorld World;

        public class Actor
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        private const int ImageSizeX = 512;
        private const int ImageSizeY = 512;

        private static readonly Image image = new Bitmap(ImageSizeX, ImageSizeY);

        private readonly Actor[] _actors = new Actor[500];

        public MainForm()
        {
            InitializeComponent();

            var worldGen = WorldsGenerator.GetDefault(128, 128);
            worldGen.CreateSwordsman(Team.Blue, 5, 5);
            worldGen.CreateSwordsman(Team.Red, 10, 10);

            SetWorld(worldGen.GetWorld());
        }

        public void SetWorld(IWorld world)
        {
            World = world;
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
                        
                        DrawGrid(z, World);
                        DrawUnits(z, World);
                    }
                    
                    pictureBox1.Image = image;
                    
                    //pictureBox1.Invalidate();
                }));

                Task.Delay(50).Wait();
            }
        }

        private void DrawUnits(Graphics gfx, IWorld world)
        {
            int dX = ImageSizeX / world.Width;
            int dY = ImageSizeY / world.Length;

            foreach (var unit in world.Army.GetUnits())
            {
                gfx.DrawEllipse(TeamAPen, unit.X * dX, unit.Y * dY, dX, dY);
            }
        }

        private void DrawGrid(Graphics gfx, IWorld world)
        {
            int stepX = ImageSizeX / world.Width;
            int stepY = ImageSizeY / world.Length;

            for (int x = 0; x < ImageSizeX; x += stepX)
            {
                gfx.DrawLine(Pen, new Point(x, 0), new Point(x, ImageSizeY));
            }

            for (int y = 0; y < ImageSizeY; y += stepY)
            {
                gfx.DrawLine(Pen, new Point(0, y), new Point(ImageSizeX, y));
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            var rnd = new Random(DateTime.Now.GetHashCode());
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i] = new Actor { X = 50 + rnd.Next(400), Y = 50 + rnd.Next(400) };
            }

            Task.Factory.StartNew(Render);
        }
    }
}
