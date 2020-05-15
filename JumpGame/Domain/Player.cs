using System.Drawing;
using System.IO;

namespace JumpGame
{
    public class Player
    {
        public Image SonicRunning { get; private set; }
        public Image SonicStanding { get; private set; }
        public Condition CurrentImg { get; private set; }
        public Point Position { get; private set; }
        public int Size { get; private set; }
        public int Score { get; private set; }
        public float GravityValue { get; set; }
        public bool IsAlive { get; set; }

        public Player(int x, int y)
        {
            var file = new FileInfo("Images\\sonic.png").FullName;
            var file2 = new FileInfo("Images\\sonic2.png").FullName;
            SonicRunning = new Bitmap(Image.FromFile(file));
            SonicStanding = new Bitmap(Image.FromFile(file2));
            Position = new Point(x, y);
            Size = 50;
            GravityValue = 0.2f;
            IsAlive = true;
        }

        public void UpScore() => Score++;

        public Image ChangeImg()
        {
            if (CurrentImg == Condition.Running)
            {
                CurrentImg = Condition.Standing;
                return SonicRunning;
            }
            else
            {
                CurrentImg = Condition.Running;
                return SonicStanding;
            }   
        }

        public void Jump(float Gravity, int yCoordinate)
        {
            if (Position.Y + (int)Gravity <= yCoordinate)
                Position = new Point(Position.X, Position.Y + (int)Gravity);
        }

        public enum Condition
        {
            Running,
            Standing
        }
    }
}
