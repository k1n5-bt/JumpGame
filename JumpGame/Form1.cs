using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GameLevel = JumpGame.GameLevels.GameLevel;

namespace JumpGame
{
    public partial class Form1 : Form
    {
        public Game game;
        private GameLevel level;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(Update);
            level = GameLevel.DefaultLevel;
            Init(level);
        }

        private void Init(GameLevel newLevel)
        {
            Text = "Score: 0";
            timer1.Start();
            this.BackgroundImage = new Bitmap(Image.FromFile(new FileInfo("Images\\backTown.jpg").FullName));
            this.game = GameCreator.CreateLevel(newLevel);
        }

        private void Update(object sender, EventArgs e)
        {
            game.Update();
            if (!game.Player.IsAlive)
            {
                timer1.Stop();
                var a = MessageBox.Show("Вы проиграли. Начать с начала?", "123", MessageBoxButtons.YesNo);
                if (a == DialogResult.Yes)
                    Init(level);
                else
                    Application.Exit();
            }
            else
            {
                Text = "Score: " + game.Player.Score;
            }
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.DrawImage(game.Sonic, game.Player.Position.X, game.Player.Position.Y, game.Player.Size, game.Player.Size);
            graphics.DrawImage(game.Wall.WallImg, game.Wall.X, game.Wall.Y, game.Wall.SizeX, game.Wall.SizeY);
        }

        public void button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                game.Jump();
        }

        private void fastLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            level = GameLevel.FastLevel;
            Init(level);
        }

        private void defaultLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            level = GameLevel.DefaultLevel;
            Init(level);
        }
    }
}
