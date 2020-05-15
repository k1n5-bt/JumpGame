using JumpGame.Domain;
using System;
using System.Drawing;

namespace JumpGame
{
    public class Game
    {
        private readonly int deltaWallAndPlayer = 80;
        private readonly int yCoordinateFloor = 420;
        public Player Player { get; private set; } = new Player(0, 420);
        public IEssence Wall { get; private set; }
        public Image Sonic { get; private set; }
        public float Gravity { get; private set; }
        public int Speed { get; private set; }
        public int Walls { get; private set; }

        public Game(Wall wall, int speed, int wallsCount)
        {
            Wall = wall;
            Sonic = Player.SonicStanding;
            Speed = speed;
            Walls = wallsCount;
        }

        public void Update()
        {
            if (Wall.Collide(Player))
            {
                Player.IsAlive = false;
                return;
            }
            Sonic = Player.ChangeImg();
            Gravity += Player.GravityValue;
            Player.Jump(Gravity, yCoordinateFloor);
            if (Player.GravityValue != 0.2f)
                Player.GravityValue = 0.2f;
            if (Player.Score > Walls)
            {
                Speed += 1;
                Walls *= 2;
            }
            Wall.MoveWall(Speed);
            CreateNewWall();
        }

        public void CreateNewWall()
        {
            if (Wall.X < Player.Position.X - deltaWallAndPlayer)
            {
                var rnd = new Random();
                var i = rnd.Next(0, 3);
                if (Wall is Wall || Wall is Bat)
                    Player.UpScore();
                if (i == 0)
                    Wall = new Wall();
                else if (i == 1)
                    Wall = new Cloud();
                else
                    Wall = new Bat();
            }
        }

        public void Jump()
        {
            if (Player.IsAlive)
            {
                if (Player.Position.Y <= yCoordinateFloor && Player.Position.Y > yCoordinateFloor - 100f)
                {
                   Gravity = -7f;
                   Player = new Player(Player.Position.X, Player.Position.Y + (int)Gravity);
                }
            }
        }
    }
}
