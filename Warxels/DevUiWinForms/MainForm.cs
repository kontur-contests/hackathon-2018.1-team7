using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic;
using GameLogic.Helper;

namespace DevUiWinForms
{
    public enum DrawMode
    {
        Units, Terrain
    }
    public partial class MainForm : Form
    {
        private DrawMode _drawMode = DrawMode.Units;

        private Point squareBegin;
        private Point squareEnd;
        private bool renderSquare = false;
        private bool squareSelection = false;

        private static bool Paused = true;
        private const int DefaultDelay = 100;
        private static int Delay = DefaultDelay;
        private static readonly Brush MarshBrush = new SolidBrush(Color.FromArgb(64,0,0,255));
        private static readonly Pen Pen = new Pen(Brushes.AliceBlue);
        private static readonly Pen ProjectilePen = new Pen(Brushes.Brown);

        private static readonly Pen SquarePen = new Pen(Color.Black);
        private static IWorld World;
        private WorldsGenerator WorldGen;
        private readonly Graphics _gfx;

        private const int ImageSizeX = 1024;
        private const int ImageSizeY = 1024;

        private static readonly Image image = new Bitmap(ImageSizeX, ImageSizeY);

        public MainForm()
        {
            InitializeComponent();

            WorldGen = WorldsGenerator.GetDefault(64, 64);
            textBoxWorldX.Text = "64";
            textBoxWorldY.Text = "64";

            SetWorld(WorldGen.GetWorld());

            _gfx = Graphics.FromImage(image);

            UpdateDrawMode();
            
        }

        public void SetWorld(IWorld world)
        {
            World = world;
        }


        private void Render()
        {
            while (true)
            {
                if (!Paused)
                    World.DoTick();
                
                var world = World;

                {
                    _gfx.Clear(Color.White);

                    DrawGrid(_gfx, world);
                    DrawTerrain(_gfx, world);
                    DrawUnits(_gfx, world);
                    DrawProjectiles(_gfx, world);

                    if (renderSquare)
                    {
                        var coord1 = ControlCoordsToImageCoords(squareBegin.X, squareBegin.Y);
                        var coord2 = ControlCoordsToImageCoords(squareEnd.X, squareEnd.Y);
                        _gfx.DrawRectangle(SquarePen, coord1.X, coord1.Y, coord2.X-coord1.X, coord2.Y-coord1.Y);
                    }
                }

                pictureBox1.BeginInvoke(new Action(() =>
                {
                    pictureBox1.Image = image;
                }));

                Task.Delay(Delay).Wait();
            }
        }

        private void DrawTerrain(Graphics gfx, IWorld world)
        {
            int dX = ImageSizeX / world.Width;
            int dY = ImageSizeY / world.Length;

            for (int i=0;i<world.Terrain.GetLength(0);i++)
                for (int j=0;j<world.Terrain.GetLength(1); j++)
                    switch (world.Terrain[i, j])
                    {
                        case 1: gfx.FillRectangle(MarshBrush, i * dX, j * dY, dX, dY);break;
                        default:break;
                    }
        }

        private void DrawProjectiles(Graphics gfx, IWorld world)
        {
            int dX = ImageSizeX / world.Width;
            int dY = ImageSizeY / world.Length;

            foreach (var projectile in world.GetProjectiles())
            {
                gfx.DrawEllipse(ProjectilePen, projectile.X * dX, projectile.Y * dY, dX/2 , dY/2);
            }
        }


        private Pen[] TeamAPens = new Pen[] {
            new Pen(Color.FromArgb(50, Color.Red)),
            new Pen(Color.FromArgb(100, Color.Red)),
            new Pen(Color.FromArgb(150, Color.Red)),
            new Pen(Color.FromArgb(200, Color.Red)),
            new Pen(Color.FromArgb(255, Color.Red))
        };

        private Pen[] TeamBPens = new Pen[] {
            new Pen(Color.FromArgb(50, Color.Blue)),
            new Pen(Color.FromArgb(100, Color.Blue)),
            new Pen(Color.FromArgb(150, Color.Blue)),
            new Pen(Color.FromArgb(200, Color.Blue)),
            new Pen(Color.FromArgb(255, Color.Blue))
        };

        private SolidBrush[] TeamASolidPens = new SolidBrush[] {
            new SolidBrush(Color.FromArgb(50, Color.Red)),
            new SolidBrush(Color.FromArgb(100, Color.Red)),
            new SolidBrush(Color.FromArgb(150, Color.Red)),
            new SolidBrush(Color.FromArgb(200, Color.Red)),
            new SolidBrush(Color.FromArgb(255, Color.Red))
        };

        private SolidBrush[] TeamBSolidPens = new SolidBrush[] {
            new SolidBrush(Color.FromArgb(50, Color.Blue)),
            new SolidBrush(Color.FromArgb(100, Color.Blue)),
            new SolidBrush(Color.FromArgb(150, Color.Blue)),
            new SolidBrush(Color.FromArgb(200, Color.Blue)),
            new SolidBrush(Color.FromArgb(255, Color.Blue))
        };

        private void DrawUnits(Graphics gfx, IWorld world)
        {
            int dX = ImageSizeX / world.Width;
            int dY = ImageSizeY / world.Length;

            foreach (var unit in world.Army.GetUnits())
            {
                var healthPercentageIndex = (int)Math.Floor(unit.GetHealthPercentage() / 25);
                switch (unit.UnitType)
                {
                    case UnitType.SwordsMan:
                        gfx.DrawEllipse(unit.Team == Team.Red ? TeamAPens[healthPercentageIndex]: TeamBPens[healthPercentageIndex], unit.X * dX, unit.Y * dY, dX, dY); break;
                    case UnitType.HorseMan:
                        gfx.DrawRectangle(unit.Team == Team.Red ? TeamAPens[healthPercentageIndex]: TeamBPens[healthPercentageIndex], unit.X * dX, unit.Y * dY, dX, dY); break;
                    case UnitType.Archer:
                        gfx.FillEllipse(unit.Team == Team.Red ? TeamASolidPens[healthPercentageIndex] : TeamBSolidPens[healthPercentageIndex], unit.X * dX, unit.Y * dY, dX, dY); break;
                }

            }
        }

        private void DrawGrid(Graphics gfx, IWorld world)
        {
            int stepX = ImageSizeX / world.Width;
            int stepY = ImageSizeY / world.Length;

            for (int x = 0; x < ImageSizeX; x += stepX)
            {
                gfx.DrawLine(Pen, x, 0, x, ImageSizeY);
            }

            for (int y = 0; y < ImageSizeY; y += stepY)
            {
                gfx.DrawLine(Pen, 0, y, ImageSizeX, y);
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            Task.Factory.StartNew(Render);
        }

        private Point ControlCoordsToWorldCoords(int x, int y)
        {
            return new Point(x * World.Width / pictureBox1.Width, y * World.Length / pictureBox1.Height);
        }

        private Point ControlCoordsToImageCoords(int x, int y)
        {
            return new Point(x * ImageSizeX / pictureBox1.Width, y * ImageSizeY / pictureBox1.Height);
        }

        private void UnitDrawMouseUp(MouseEventArgs e)
        {
            if (!squareSelection)
            {
                if (e.Button == MouseButtons.Left)
                {
                    var coords = ControlCoordsToWorldCoords(e.X, e.Y);
                    AddUnit(_radioTeamA.Checked ? Team.Red : Team.Blue, coords.X, coords.Y);
                }
            }
            else
            {
                UnitType t = UnitType.SwordsMan;
                if (radioButtonUnitSwords.Checked)
                    t = UnitType.SwordsMan;
                else if (radioButtonUnitHorse.Checked)
                    t = UnitType.HorseMan;
                if (radioButtonUnitArcher.Checked)
                    t = UnitType.Archer;

                
                var coords1 = ControlCoordsToWorldCoords(squareBegin.X, squareBegin.Y);
                var coords2 = ControlCoordsToWorldCoords(squareEnd.X, squareEnd.Y);
                int amount = int.Parse(textBoxSquareAmount.Text);
                WorldGen.AddUnitSquare(_radioTeamA.Checked ? Team.Red : Team.Blue, coords1.Y, coords1.X, coords2.X - coords1.X, coords2.Y - coords1.Y,
                    t, amount);
            }
        }

        private void TerrainDrawMouseUp(MouseEventArgs e)
        {
            if (!squareSelection)
            {
                var coords1 = ControlCoordsToWorldCoords(squareBegin.X, squareBegin.Y);
                var size = int.Parse(textBoxTerrainBrushSize.Text);
                World.SetTerrain(coords1.Y, coords1.X, coords1.Y+size, coords1.X+size, (byte)comboBoxTerrain.SelectedIndex);
            }
            else
            {
                var coords1 = ControlCoordsToWorldCoords(squareBegin.X, squareBegin.Y);
                var coords2 = ControlCoordsToWorldCoords(squareEnd.X, squareEnd.Y);

                World.SetTerrain(coords1.Y, coords1.X, coords2.Y, coords2.X, (byte)comboBoxTerrain.SelectedIndex);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (_drawMode)
            {
                case DrawMode.Units: UnitDrawMouseUp(e); break;
                case DrawMode.Terrain: TerrainDrawMouseUp(e); break;
            }

            if (squareSelection)
                renderSquare = false;
        }

        private void AddUnit(Team team, int worldX, int worldY)
        {
            if (World.Army.GetUnit(worldY, worldX) == null)
            {
                if (radioButtonUnitSwords.Checked)
                    WorldGen.CreateUnit(UnitType.SwordsMan, team, worldY, worldX);
                if (radioButtonUnitHorse.Checked)
                    WorldGen.CreateUnit(UnitType.HorseMan, team, worldY, worldX);
                if (radioButtonUnitArcher.Checked)
                    WorldGen.CreateUnit(UnitType.Archer, team, worldY, worldX);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGameSpeedNormal.Checked)
                Delay = DefaultDelay;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGameSpeedX2.Checked)
                Delay = DefaultDelay / 2;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGameSpeedX4.Checked)
                Delay = DefaultDelay / 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetPaused(!Paused);
        }

        private void SetPaused(bool paused)
        {
            Paused = paused;

            button1.Text = Paused ? "Start" : "Pause";
        }

        private void UnitDrawMouseMove(MouseEventArgs e)
        {
            if (!squareSelection)
            {
                var coords = ControlCoordsToWorldCoords(e.X, e.Y);
                if (e.Button == MouseButtons.Left)
                    AddUnit(_radioTeamA.Checked ? Team.Red : Team.Blue, coords.X, coords.Y);
                else
                    if (e.Button == MouseButtons.Right)
                    AddUnit(_radioTeamA.Checked ? Team.Blue : Team.Red, coords.X, coords.Y);
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                    squareEnd = new Point(e.X, e.Y);
            }
        }

        private void TerrainDrawMouseMove(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (!squareSelection)
            {
                var coords1 = ControlCoordsToWorldCoords(e.X, e.Y);
                var size = int.Parse(textBoxTerrainBrushSize.Text);
                World.SetTerrain(coords1.Y, coords1.X, coords1.Y + size, coords1.X + size, (byte)comboBoxTerrain.SelectedIndex);
            }
            else
            {
                squareEnd = new Point(e.X, e.Y);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            switch (_drawMode)
            {
                case DrawMode.Units: UnitDrawMouseMove(e);break;
                case DrawMode.Terrain: TerrainDrawMouseMove(e);break;
            }
        }

        private void buttonGenerateWorld_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(textBoxWorldX.Text);
            int y = Int32.Parse(textBoxWorldY.Text);

            if (comboBoxPreset.SelectedIndex == -1)
                WorldGen = WorldsGenerator.GetDefault(y, x);
            else
                WorldGen = WorldsGenerator.CreatePreset(y, x);

            var world = WorldGen.GetWorld();
            SetWorld(world);
            SetPaused(true);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (squareSelection)
            {
                squareBegin = squareEnd = new Point(e.X, e.Y);
                
                renderSquare = true;
            }
        }

        private void radioButtonX8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonX8.Checked)
                Delay = DefaultDelay / 8;
        }

        private void tabControlUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDrawMode();
        }

        private void UpdateDrawMode()
        {
            switch (tabControlUnits.SelectedIndex)
            {
                case 0: _drawMode = DrawMode.Units; break;
                case 1: _drawMode = DrawMode.Terrain; break;
            }

            CheckRenderSquare();
        }

        private void radioButtonTerrainBrush_CheckedChanged(object sender, EventArgs e)
        {
            CheckRenderSquare();
        }

        private void radioButtonTerrainSquare_CheckedChanged(object sender, EventArgs e)
        {
            CheckRenderSquare();
        }

        private void CheckRenderSquare()
        {
            squareSelection = radioButtonTerrainSquare.Checked && _drawMode == DrawMode.Terrain
                || radioButtonSquare.Checked && _drawMode == DrawMode.Units;
        }

        private void radioButtonSquare_CheckedChanged(object sender, EventArgs e)
        {
            CheckRenderSquare();
        }

        private void buttonUnitsSave_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "*.units|*.units|*.*|*.*";
            dialog.AddExtension = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                World.SaveUnits(dialog.FileName);
            }
        }

        

        private void buttonTerrainLoad_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "*.terr|*.terr|*.*|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                WorldGen = SaveLoadHelper.LoadTerrainFromFile(dialog.FileName);
                SetWorld(WorldGen.GetWorld());
            }
        }
        
        
        private void buttonTerrainSave_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "*.terr|*.terr|*.*|*.*";
            dialog.AddExtension = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                World.SaveTerrain(dialog.FileName);
            }
        }

        private void buttonUnitsLoad_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "*.units|*.units|*.*|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
                WorldGen.LoadUnitsFromFile(dialog.FileName);
        }
    }
}
