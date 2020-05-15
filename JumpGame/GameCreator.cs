using GameLevel = JumpGame.GameLevels.GameLevel;

namespace JumpGame
{
    static public class GameCreator
    {
        public static Game CreateLevel(GameLevel nameLevel)
        {
            switch (nameLevel)
            {
                case (GameLevel.DefaultLevel):
                        return CreateDefault();
                case (GameLevel.FastLevel):
                        return CreateFastLevel();
                default:
                        return CreateDefault();
            }
        }

        public static Game CreateDefault()
        {
            return new Game(new Wall(), 2, 2);
        }

        public static Game CreateFastLevel()
        {
            return new Game(new Wall(), 7, 2);
        }
    }
}
