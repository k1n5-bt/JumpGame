using System.Drawing;
using System.IO;

namespace JumpGame.Domain
{
    class Cloud : IEssence
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public Image WallImg { get; set; } = new Bitmap(Image.FromFile(new FileInfo("Images\\cloud.png").FullName));
        public int Size { get; set; }

        public Cloud()
        {
            X = 550;
            Y = 300;
            SizeX = 75;
            SizeY = 75;
        }

        public bool Collide(Player player) => false;

        public IEssence CreateNewWall() => new Cloud();

        public void MoveWall(int dx) => X -= dx;
    }
}
