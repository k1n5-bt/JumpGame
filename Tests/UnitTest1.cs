using JumpGame;
using JumpGame.Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class UnitTest1
    {
        Game game;

        [SetUp]
        public void Set()
        {
            game = JumpGame.GameCreator.CreateDefault();
        }

        [Test]
        public void Game_ShouldMakeNewWall()
        {
            while (!(game.Wall.X >= game.Player.Position.X))
            {
                game.Wall.MoveWall(2);
            }
            Assert.AreEqual(500, game.Wall.X);
        }

        [Test]
        public void Game_ShouldEnd_WhenPlayerCollideWithWall()
        {
            while (!game.Wall.Collide(game.Player))
                game.Update();
            game.Update();
            Assert.AreEqual(false, game.Player.IsAlive);
        }

        [Test]
        public void Player_ShouldCollideWithWall()
        {
            while (game.Player.IsAlive)
            {
                game.Update();
            }
            Assert.AreEqual(true, game.Wall.Collide(game.Player));
        }

        [Test]
        public void Player_ShouldJump()
        {
            game.Player.Jump(-7, 420);
            Assert.AreEqual(413, game.Player.Position.Y);
        }

        [Test]
        public void Player_ShouldCollideWithBat()
        {
            while (!(game.Wall is Bat) && game.Wall.Y != game.Player.Position.Y)
            {
                game.Wall.MoveWall(2);
                game.CreateNewWall();
            }
            while (game.Player.IsAlive)
            {
                game.Update();
            }
            Assert.AreEqual(true, game.Wall.Collide(game.Player));
        }

    }
}
