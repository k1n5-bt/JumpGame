using System.Drawing;

namespace JumpGame
{
    public interface IEssence
    {
        int X { get; set; }
        int Y { get; set; }
        int SizeX { get; set; }
        int SizeY { get; set; }
        Image WallImg { get; set; }
        int Size { get; set; }
        void MoveWall(int dx);
        bool Collide(Player player);
    }
}
