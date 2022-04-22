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

            Player player = new Player(new Position(0, 0));
            World.Singleton.Creatures.Add(player);

            InputHandler.Singleton.AddInputListener(
                new InputListener(Keys.W, (k) => {
                    player.TryMoveTo(
                        new Position(player.Position.x,
                        player.Position.y - 1));
                    World.Singleton.Tick();
                }));
            InputHandler.Singleton.AddInputListener(
                new InputListener(Keys.S, (k) => {
                    player.TryMoveTo(
                        new Position(player.Position.x,
                        player.Position.y + 1));
                    World.Singleton.Tick();
                }));
            InputHandler.Singleton.AddInputListener(
                new InputListener(Keys.D, (k) => {
                    player.TryMoveTo(
                        new Position(player.Position.x + 1,
                        player.Position.y));
                    World.Singleton.Tick();
                }));
            InputHandler.Singleton.AddInputListener(
                new InputListener(Keys.A, (k) => {
                    player.TryMoveTo(
                        new Position(player.Position.x - 1,
                        player.Position.y));
                    World.Singleton.Tick();
                }));



            InputHandler.Singleton.AddInputListener(
                new InputListener(Keys.Up, (k) => {
                    World.Singleton.ViewPosition.y--;
                }));
            InputHandler.Singleton.AddInputListener(
                new InputListener(Keys.Down, (k) => {
                    World.Singleton.ViewPosition.y++;
                }));
            InputHandler.Singleton.AddInputListener(
                new InputListener(Keys.Right, (k) => {
                    World.Singleton.ViewPosition.x++;
                }));
            InputHandler.Singleton.AddInputListener(
                new InputListener(Keys.Left, (k) => {
                    World.Singleton.ViewPosition.x--;
                }));
        }
    }
}