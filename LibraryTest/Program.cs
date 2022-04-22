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
            
            World.Singleton.Creatures.Add(new Player(new Position(0, 0)));
            World.Singleton.Creatures.Add(new Player(new Position(1, 1)));
            World.Singleton.Creatures.Add(new Player(new Position(5, 5)));

            InputHandler.Singleton.AddInputListener(
                new InputListener(Keys.W, (k) => {
                    World.Singleton.ViewPosition.y--;
                }));
            InputHandler.Singleton.AddInputListener(
                new InputListener(Keys.S, (k) => {
                    World.Singleton.ViewPosition.y++;
                }));
            InputHandler.Singleton.AddInputListener(
                new InputListener(Keys.D, (k) => {
                    World.Singleton.ViewPosition.x++;
                }));
            InputHandler.Singleton.AddInputListener(
                new InputListener(Keys.A, (k) => {
                    World.Singleton.ViewPosition.x--;
                }));
        }
    }
}