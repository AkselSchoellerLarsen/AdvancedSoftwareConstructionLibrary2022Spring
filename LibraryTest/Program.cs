using Library;
using Library.Util;
using LibraryTest.Entities;

namespace LibraryTest {
    internal static class Program {
        static void Main(string[] args) {
            ApplicationConfiguration.Initialize();

            SetupGameWorld();

            Application.Run(new TestScreen());
        }

        private static void SetupGameWorld() {
            World.Singleton.ViewPosition = new Position(0, 0);

            Player player = new Player(new Position(5, 5));
            World.Singleton.Creatures.Add(player);

            new InputListener(Keys.W, (k) => {
                player.TryMoveTo(
                    new Position(player.Position.x,
                    player.Position.y - 1));
                World.Singleton.ViewPosition.y--;
                World.Singleton.Tick();
            });
            new InputListener(Keys.S, (k) => {
                player.TryMoveTo(
                    new Position(player.Position.x,
                    player.Position.y + 1));
                World.Singleton.ViewPosition.y++;
                World.Singleton.Tick();
            });
            new InputListener(Keys.D, (k) => {
            player.TryMoveTo(
                new Position(player.Position.x + 1,
                player.Position.y));
                World.Singleton.ViewPosition.x++;
                World.Singleton.Tick();
            });
            new InputListener(Keys.A, (k) => {
                player.TryMoveTo(
                    new Position(player.Position.x - 1,
                    player.Position.y));
                World.Singleton.ViewPosition.x--;
                World.Singleton.Tick();
            });

            new InputListener(Keys.Up, (k) => {
                World.Singleton.ViewPosition.y--;
            });
            new InputListener(Keys.Down, (k) => {
                World.Singleton.ViewPosition.y++;
            });
            new InputListener(Keys.Right, (k) => {
                World.Singleton.ViewPosition.x++;
            });
            new InputListener(Keys.Left, (k) => {
                World.Singleton.ViewPosition.x--;
            });
        }
    }
}