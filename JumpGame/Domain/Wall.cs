using System;
using System.Drawing;
using System.IO;

namespace JumpGame
{
    public class Wall : IEssence
    {
        public int X { get; set; }
        public int Y { get; set; }
        private readonly int deltaToFloor = 50;
        private readonly int deltaToPlayer = 10;
        public int Size { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public Image WallImg { get; set; }

        public Wall(int x = 500)
        {
            var rnd = new Random();
            var file = new FileInfo("Images\\wall.png").FullName;
            WallImg = new Bitmap(Image.FromFile(file));
            this.X = x;
            this.Y = rnd.Next(350, 400);
            SizeX = 150;
            SizeY = 250;
        }

        public void MoveWall(int dx) => X -= dx;

        public bool Collide(Player player)
        {
            for (int i = deltaToPlayer; i < SizeX; i++)
            {
                if (player.Position.X == X + i + deltaToPlayer && player.Position.Y >= Y - deltaToFloor)
                    return true;
            }
            return false;
        }
    }
}
