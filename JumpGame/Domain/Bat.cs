using System;
using System.Drawing;
using System.IO;

namespace JumpGame.Domain
{
    public class Bat : IEssence
    {
        public int X { get; set; }
        public int Y { get; set; }
        private readonly int deltaToFloor = 50;
        private readonly int deltaToPlayer = 10;
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        private Condition CurrentImg = Condition.Flying2;
        public Image WallImg { get; set; } = new Bitmap(Image.FromFile(new FileInfo("Images\\bat1.png").FullName));
        public int Size { get; set; }

        public Bat()
        {
            var rnd = new Random();
            X = 550;
            Y = rnd.Next(300, 350);
            SizeX = 75;
            SizeY = 75;
        }

        public bool Collide(Player player)
        {
            for (int i = deltaToPlayer; i < SizeX; i++)
            {
                if (player.Position.X == X + i - deltaToPlayer && player.Position.Y >= Y - deltaToFloor && player.Position.Y < Y + deltaToFloor)
                    return true;
            }
            return false;
        }

        public void MoveWall(int dx)
        {
            ChangeImg();
            X -= dx;
        }

        public void ChangeImg()
        {
            if (CurrentImg == Condition.Flying)
            {
                CurrentImg = Condition.Flying2;
                WallImg = new Bitmap(Image.FromFile(new FileInfo("Images\\bat1.png").FullName));
            }
            else
            {
                CurrentImg = Condition.Flying;
                WallImg = new Bitmap(Image.FromFile(new FileInfo("Images\\bat2.png").FullName));
            }
        }

        public enum Condition
        {
            Flying,
            Flying2
        }
    }
}
