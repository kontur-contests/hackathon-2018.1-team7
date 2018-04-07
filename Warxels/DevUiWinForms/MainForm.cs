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
        private static bool Paused = true;
        private static int Delay = 500;
        private static readonly Pen Pen = new Pen(Brushes.AliceBlue);
        private static readonly Pen TeamAPen = new Pen(Brushes.Red);
        private static readonly Pen TeamBPen = new Pen(Brushes.Blue);
        private static IWorld World;
        private WorldsGenerator WorldGen;
        private readonly object SyncRoot = new object();

        private const int ImageSizeX = 512;
        private const int ImageSizeY = 512;

        private static readonly Image image = new Bitmap(ImageSizeX, ImageSizeY);

        public MainForm()
        {
            InitializeComponent();

            WorldGen = WorldsGenerator.GetDefault(64, 64);
            textBoxWorldX.Text = "64";
            textBoxWorldY.Text = "64";

            SetWorld(WorldGen.GetWorld());
        }

        public void SetWorld(IWorld world)
        {
            World = world;
        }

        private void Tick()
        {
            while (true)
            {
                if (!Paused)
                    lock(SyncRoot)
                        World.DoTick();

                Task.Delay(Delay).Wait();
            }
        }

        private void Render()
        {
            while (true)
            {
                var world = World;
                

                pictureBox1.Invoke(new Action(() =>
                {
                    using (var z = Graphics.FromImage(image))
                    {
                        z.Clear(Color.White);

                        DrawGrid(z, world);
                        DrawUnits(z, world);
                    }
                    pictureBox1.Image = image;
                }));

                Task.Delay(25).Wait();
            }
        }

        private void DrawUnits(Graphics gfx, IWorld world)
        {
            int dX = ImageSizeX / world.Width;
            int dY = ImageSizeY / world.Length;
            lock(SyncRoot)
            foreach (var unit in world.Army.GetUnits())
            {
                gfx.DrawEllipse(unit.Team==Team.Red ? TeamAPen : TeamBPen, unit.X * dX, unit.Y * dY, dX, dY);
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

            Task.Factory.StartNew(Render);
            Task.Factory.StartNew(Tick);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                AddUnit(_radioTeamA.Checked ? Team.Red : Team.Blue, e.X * World.Width / pictureBox1.Width, e.Y * World.Length / pictureBox1.Height);                        
        }

        private void AddUnit(Team team, int worldX, int worldY)
        {
            lock(SyncRoot)
            if (World.Army.GetUnit(worldY, worldX) == null)
                WorldGen.CreateSwordsman(team, worldY, worldX);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGameSpeedNormal.Checked)
                Delay = 500;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGameSpeedX2.Checked)
                Delay = 250;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGameSpeedX4.Checked)
                Delay = 125;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Paused = !Paused;

            button1.Text = Paused ? "Start" : "Pause";
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                AddUnit(_radioTeamA.Checked ? Team.Red : Team.Blue, e.X * World.Width / pictureBox1.Width, e.Y * World.Length / pictureBox1.Height);
            else
                if (e.Button == MouseButtons.Right)
                AddUnit(_radioTeamA.Checked ? Team.Blue : Team.Red, e.X * World.Width / pictureBox1.Width, e.Y * World.Length / pictureBox1.Height);
        }

        private void buttonGenerateWorld_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(textBoxWorldX.Text);
            int y = Int32.Parse(textBoxWorldY.Text);

           
                WorldGen = WorldsGenerator.GetDefault(y, x);
                var world = WorldGen.GetWorld();
                SetWorld(world);
            
        }
    }
}
